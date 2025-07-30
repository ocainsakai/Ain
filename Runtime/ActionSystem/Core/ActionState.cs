
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
    public abstract class ActionState : IState
    {
        public virtual ActionStateType Type { get; protected set; }
        public abstract void OnEnter();
        public abstract void Tick();
        public abstract void OnExit();
    }
}