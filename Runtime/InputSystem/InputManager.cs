using UnityEngine;

namespace Ain.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        private IInputSource _inputSource;

        void Awake()
        {
            _inputSource = new PlayerInputSource();
            _inputSource.Enable();
        }

        void OnDestroy()
        {
            _inputSource.Disable();
        }

        public void SetInputSource(IInputSource source)
        {
            _inputSource.Disable();
            _inputSource = source;
            _inputSource.Enable();
        }
    }
}