using SkullHollow.Systems.SocialGraph;

namespace SkullHollow.Systems.AIDirector
{
    /// <summary>
    /// Il macro-agente che regola stabilità, narrativa (anchors) e deviazioni (probability shifter).
    /// </summary>
    public class AIDirectorManager
    {
        private SocialGraphManager _socialGraph;

        public AIDirectorManager(SocialGraphManager graph)
        {
            _socialGraph = graph;
        }

        public void MonitorTopology()
        {
            // Analizza il grafo per evitare collassi
        }

        public void ShiftProbabilities()
        {
            // Inietta perturbazioni se il giocatore diverge troppo
        }
    }
}
