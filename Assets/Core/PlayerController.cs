using UnityEngine;
using UnityEngine.InputSystem;

namespace SkullHollow.Core
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float gravity = -9.81f;

        private CharacterController _controller;
        private Vector3 _velocity;

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            float x = 0f;
            float z = 0f;

            // Lettura input diretta col nuovo Input System
            if (Keyboard.current != null)
            {
                if (Keyboard.current.wKey.isPressed) z += 1f;
                if (Keyboard.current.sKey.isPressed) z -= 1f;
                if (Keyboard.current.aKey.isPressed) x -= 1f;
                if (Keyboard.current.dKey.isPressed) x += 1f;
                
                // Freccette come alternativa
                if (Keyboard.current.upArrowKey.isPressed) z += 1f;
                if (Keyboard.current.downArrowKey.isPressed) z -= 1f;
                if (Keyboard.current.leftArrowKey.isPressed) x -= 1f;
                if (Keyboard.current.rightArrowKey.isPressed) x += 1f;
            }
            
            // Normalizziamo per evitare che andare in diagonale sia più veloce
            Vector2 inputDir = new Vector2(x, z).normalized;

            // Calcolo direzione locale rispetto a dove guarda il player
            Vector3 move = transform.right * inputDir.x + transform.forward * inputDir.y;
            _controller.Move(move * moveSpeed * Time.deltaTime);

            // Gravità molto basilare
            if (_controller.isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            _velocity.y += gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }
}
