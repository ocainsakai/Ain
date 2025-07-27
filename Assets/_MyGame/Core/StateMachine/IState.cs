namespace Ain.StateMachineSystem
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
        void Tick();
    }
}