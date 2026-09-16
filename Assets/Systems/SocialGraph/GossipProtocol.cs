namespace SkullHollow.Systems.SocialGraph
{
    /// <summary>
    /// La tupla che viaggia lungo gli archi del grafo (diffusione epidemica).
    /// </summary>
    public struct GossipEvent
    {
        public float Timestamp;
        public int SourceAgentID;
        public string Action;
        public int VictimID;
        public float Weight;
    }

    /// <summary>
    /// Gestisce il decadimento e la distorsione dell'informazione.
    /// </summary>
    public class GossipProtocol
    {
        public void Propagate(GossipEvent gossipEvent)
        {
            // Propagazione ai nodi vicini
            // Decadimento dell'accuratezza a ogni salto
        }
    }
}
