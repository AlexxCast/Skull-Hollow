namespace SkullHollow.Systems.SemanticLayer
{
    /// <summary>
    /// Genera intento e dialogo asincrono via LLM (cloud, lazy).
    /// </summary>
    public class SemanticManager
    {
        public SemanticManager()
        {
        }

        /// <summary>
        /// Pre-fetching asincrono: l'LLM si attiva e pre-genera 
        /// il micro-albero decisionale in background.
        /// </summary>
        public void PreFetchDialogTree(int npcId)
        {
            // Chiamata asincrona all'LLM
        }
        
        public void GenerateIntent(string validatedTuple)
        {
            // Chiamata all'LLM per generare risposta
        }
    }
}
