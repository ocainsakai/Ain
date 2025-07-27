using System;
using UnityEngine;

namespace Ain.InputSystem
{
    public static class InputEvents
    {
        public static Action<string> OnActionPressed;
        public static Action<Vector2> OnMove;
    }
}