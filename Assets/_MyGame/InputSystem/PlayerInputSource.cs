using UnityEngine;
using UnityEngine.InputSystem;


namespace Ain.InputSystem
{
    public class PlayerInputSource : IInputSource
    {
        private PlayerInput _input;

        public PlayerInputSource()
        {
            _input = new PlayerInput();

            _input.Player.Attack.performed += ctx =>
            {
                InputEvents.OnActionPressed?.Invoke("Attack");
            };

            _input.Player.OpenInventory.performed += ctx =>
            {
                InputEvents.OnActionPressed?.Invoke("OpenInventory");
            };

            _input.Player.Move.performed += ctx =>
            {
                Vector2 dir = ctx.ReadValue<Vector2>();
                InputEvents.OnMove?.Invoke(dir);
            };

            _input.Player.Move.canceled += ctx =>
            {
                InputEvents.OnMove?.Invoke(Vector2.zero);
            };
        }

        public void Enable() => _input.Enable();
        public void Disable() => _input.Disable();
    }
}