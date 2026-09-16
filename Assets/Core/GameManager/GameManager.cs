using UnityEngine;
using SkullHollow.Systems.SocialGraph;
using SkullHollow.Systems.GateLogic;
using SkullHollow.Systems.SemanticLayer;
using SkullHollow.Systems.CinematicLayer;
using SkullHollow.Systems.MissionSystem;
using SkullHollow.Systems.AIDirector;
using SkullHollow.World.SimulatedCity;
using SkullHollow.World.VisitableCity;

namespace SkullHollow.Core
{
    /// <summary>
    /// Il bootstrapper principale dell'architettura. 
    /// Implementa un semplice Service Locator / inizializzatore per garantire
    /// che i sistemi siano istanziati e collegati nell'ordine corretto.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public SocialGraphManager SocialGraph { get; private set; }
        public GateLogicManager GateLogic { get; private set; }
        public SemanticManager SemanticLayer { get; private set; }
        public CinematicManager CinematicLayer { get; private set; }
        public MissionManager MissionSystem { get; private set; }
        public AIDirectorManager AIDirector { get; private set; }
        public SimulatedCityManager SimulatedCity { get; private set; }
        public LazyInstantiator LazyInstantiator { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this.gameObject);

            InitializeSystems();
        }

        private void InitializeSystems()
        {
            // Inizializzazione moduli puri (C# classes)
            SocialGraph = new SocialGraphManager();
            SimulatedCity = new SimulatedCityManager(SocialGraph);
            AIDirector = new AIDirectorManager(SocialGraph);
            
            GateLogic = new GateLogicManager();
            SemanticLayer = new SemanticManager();
            MissionSystem = new MissionManager();
            CinematicLayer = new CinematicManager();

            // Moduli legati a Unity/Scena potrebbero essere GetComponent 
            // LazyInstantiator = GetComponent<LazyInstantiator>();

            Debug.Log("GameManager: Tutti i sistemi disaccoppiati sono stati inizializzati.");
        }

        private void Update()
        {
            // Tick dei sistemi che necessitano di update frame-by-frame (se ci sono)
            // L'ideale è mantenere CPU update costosi in thread o asincroni dove possibile
            SimulatedCity?.Tick(Time.deltaTime);
            CinematicLayer?.Tick(Time.deltaTime);
        }
    }
}
