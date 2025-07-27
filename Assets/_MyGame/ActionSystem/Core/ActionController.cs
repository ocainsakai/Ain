namespace Ain.ActionSystem
{
    using Ain.StateMachineSystem;
    using System;
    using UniRx;
    using UnityEngine;
    public class ActionController : StateMachine<ActionState>, IDisposable
    {
        private CompositeDisposable _disposables = new CompositeDisposable();
        // Current action state
        // Events
        public Subject<Unit> OnActionStarted = new Subject<Unit>();
        public Subject<Unit> OnActionCompleted = new Subject<Unit>();
        public ReactiveProperty<ActionStateType> CurrentStateType = new ReactiveProperty<ActionStateType>();

        public ActionController()
        {
            // Initialize with an idle state
            //ChangeState(new IdleState());
        }
        public override void ChangeState(IState newState)
        {
            CurrentState?.OnExit();
            _currentState = newState;
            CurrentStateType.Value = (newState as ActionState).Type;
            CurrentState.OnEnter();
            OnActionStarted.OnNext(Unit.Default);
        }
        public void Update()
        {
            CurrentState?.Tick();
        }
        public void Dispose()
        {
            _disposables.Dispose();
            OnActionStarted.Dispose();
            OnActionCompleted.Dispose();
        }
    }
}