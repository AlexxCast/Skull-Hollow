using UnityEngine;

namespace SkullHollow.World.VisitableCity
{
    /// <summary>
    /// Il "Ponte". Istanziazione lazy: legge lo stato del nodo dalla SimulatedCity
    /// e carica la geometria, interni, ecc. solo dove si trova il giocatore.
    /// </summary>
    public class LazyInstantiator : MonoBehaviour
    {
        private void Start()
        {
            // Setup iniziale
        }

        public void InstantiateRoom(int nodeId)
        {
            // 1. Legge lo stato dal SimulatedCity (es. "NPC sta dormendo")
            // 2. Carica il prefab della stanza
            // 3. Posiziona l'NPC nel letto
        }
    }
}
