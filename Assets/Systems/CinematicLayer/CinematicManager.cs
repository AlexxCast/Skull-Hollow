namespace SkullHollow.Systems.CinematicLayer
{
    /// <summary>
    /// Locale, a latenza zero. Usa Utility AI e modelli generativi 
    /// per il movimento (diffusione), IK e Blending.
    /// </summary>
    public class CinematicManager
    {
        public CinematicManager()
        {
        }

        public void Tick(float deltaTime)
        {
            // Update decision making e animazione
        }

        public void ExecuteIntent(string intent, string emotionalState)
        {
            // 1. Utility AI decide l'azione
            // 2. Sintesi del movimento (condizionata su posa+intento+emozione)
            // 3. IK (Contatti)
            // 4. Blending
        }
    }
}
