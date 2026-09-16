using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using SkullHollow.Core;

namespace SkullHollow.Editor
{
    public class SceneGenerator
    {
        [MenuItem("Skull Hollow/Generate Basic Test Scene")]
        public static void GenerateScene()
        {
            // Crea una nuova scena vuota
            Scene newScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);

            // 1. Crea il pavimento
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
            floor.name = "Floor";
            floor.transform.localScale = new Vector3(5, 1, 5);

            // 2. Crea il Player (Capsula)
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            player.name = "Player";
            player.transform.position = new Vector3(0, 1, 0);

            // Rimuovi il CapsuleCollider di default per evitare conflitti col CharacterController
            Object.DestroyImmediate(player.GetComponent<CapsuleCollider>());

            // Aggiungi il nostro script (aggiungerà automaticamente anche il CharacterController)
            player.AddComponent<PlayerController>();

            // 3. Sistema la telecamera
            Camera mainCam = Camera.main;
            if (mainCam != null)
            {
                mainCam.transform.SetParent(player.transform);
                mainCam.transform.localPosition = new Vector3(0, 0.6f, 0); // Altezza degli occhi
                mainCam.transform.localRotation = Quaternion.identity;
            }

            // 4. Salva la scena
            string scenePath = "Assets/World/TestScene.unity";
            bool success = EditorSceneManager.SaveScene(newScene, scenePath);
            
            if (success)
            {
                Debug.Log($"Scena generata e salvata con successo in: {scenePath}");
            }
            else
            {
                Debug.LogError("Errore durante il salvataggio della scena.");
            }
        }
    }
}
