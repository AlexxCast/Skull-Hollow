# Diario di sviluppo — Skull Hollow

Registro di cosa è stato fatto, delle decisioni prese e dei problemi aperti.
Serve come materia prima per i capitoli di architettura e metodologia della tesi.

> **Attenzione:** le voci possono essere scritte in bozza da Claude a partire dai commit.
> Sono appunti, non testo di tesi: vanno riletti, corretti e riscritti da Alessio
> prima di finire in qualunque capitolo. Le decisioni marcate *(da confermare)* sono
> ricostruite dal codice e non ancora verificate con lui.

## Come si aggiorna

- Una voce per settimana, la più recente in alto.
- Ogni voce ha quattro parti: **Fatto**, **Decisioni**, **Problemi / note**, **Commit**.
- La routine settimanale legge i commit della settimana e aggiunge una bozza di voce.
  Le settimane senza commit non generano voci.
- Le note scritte a mano da Alessio hanno sempre la precedenza sulle bozze automatiche.

---

## Settimana 14–20 settembre 2026 — Blocco 0: fondamenta

### Fatto
- Creato il progetto Unity 6 (editor `6000.0.74f1`) con Universal Render Pipeline
  e il nuovo Input System; primo commit nel repo.
- Configurati `.gitignore` per Unity e Git LFS (`.gitattributes`) per modelli 3D,
  audio e immagini.
- Creato lo scheletro dell'architettura: un assembly (`.asmdef`) per ogni sistema,
  sotto il namespace `SkullHollow.*`:
  - `Systems/SocialGraph` — grafo sociale (nodi = NPC, archi pesati) e
    `GossipProtocol` con la struttura `GossipEvent` (timestamp, sorgente, azione,
    vittima, peso).
  - `Systems/GateLogic` — validazione dell'intento del giocatore tramite embedding
    e cosine similarity.
  - `Systems/SemanticLayer` — intento e dialogo via LLM, asincrono, con pre-fetching.
  - `Systems/CinematicLayer` — pipeline di animazione: Utility AI → sintesi del
    movimento → IK → blending.
  - `Systems/MissionSystem` — missioni procedurali da template.
  - `Systems/AIDirector` — monitoraggio della topologia del grafo e perturbazioni.
  - `World/SimulatedCity` — simulazione astratta degli NPC, senza geometria.
  - `World/VisitableCity` — `LazyInstantiator`, carica la geometria solo vicino
    al giocatore.
- `Core/GameManager`: singleton che istanzia tutti i sistemi nell'ordine corretto
  e fa il tick di `SimulatedCity` e `CinematicLayer`.
- `Core/PlayerController`: movimento in prima persona (WASD/frecce) con
  `CharacterController` e gravità di base.
- Strumento editor `Skull Hollow > Generate Basic Test Scene` che genera
  `Assets/World/TestScene.unity` (pavimento, capsula player, camera all'altezza
  degli occhi).

### Decisioni
- **Un assembly per sistema.** Le dipendenze sono esplicite: `AIDirector` e
  `SimulatedCity` dipendono solo da `SocialGraph`; solo `Core` vede tutto.
  Questo rende concreto il disaccoppiamento descritto nel documento di architettura
  (semantico vs cinematico, città simulata vs visitabile) e permette di testare
  i sistemi separatamente. *(da confermare: era questa la motivazione?)*
- **I sistemi sono classi C# pure, non `MonoBehaviour`.** Solo `GameManager`,
  `PlayerController` e `LazyInstantiator` dipendono dalla scena. Così la logica
  di simulazione resta indipendente da Unity. *(da confermare)*
- **Service locator semplice** (`GameManager.Instance`) invece di un framework di
  dependency injection: minimo indispensabile per ora.

### Problemi / note
- Tutti i sistemi sono stub: firme e commenti, nessuna logica implementata.
- `GameManager` non è presente in nessuna scena, quindi a runtime i sistemi non
  vengono mai inizializzati. Da aggiungere a `TestScene` quando serve.
- La scena nei Build Settings è ancora `SampleScene` del template, non `TestScene`.
- Restano i file del template URP (`TutorialInfo/`, `Readme.asset`): si possono
  eliminare quando si vuole.
- Dalla roadmap del Blocco 0 manca ancora: recuperare il codice Unity↔LLM di un
  anno fa.

### Commit
- `f26b943` (16/09/2026) feat: initial commit - blocco 0
