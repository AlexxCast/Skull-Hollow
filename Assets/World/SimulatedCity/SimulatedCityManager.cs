using SkullHollow.Systems.SocialGraph;

namespace SkullHollow.World.SimulatedCity
{
    /// <summary>
    /// Totale e sempre attiva (gratis). 
    /// Ogni NPC ha uno stato (dove abita, cosa fa, ecc.).
    /// Non ha rappresentazione spaziale o mesh caricate.
    /// </summary>
    public class SimulatedCityManager
    {
        private SocialGraphManager _socialGraph;

        public SimulatedCityManager(SocialGraphManager graph)
        {
            _socialGraph = graph;
        }

        public void Tick(float deltaTime)
        {
            // Aggiorna gli stati dei nodi (chi dorme, chi lavora) 
            // a livello matematico, senza geometria.
        }
    }
}
