using UnityEngine;

namespace Ain.ActionSystem
{
    public enum ActionStateType { 
        Play,
        Sort,
        Discard,
        Idle,
        Moving,
        Casting,
        UsingItem,
        Attacking,
        Defending,
        Healing,
        Buffing,
        Debuffing,
    }
    public abstract class ActionState
    {
        public virtual ActionStateType Type { get; protected set; }
        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}