namespace Ain.ActionSystem
{
    using System;
    using System.Collections.Generic;
    using UniRx;
    using UnityEngine;
    public class ActionController : MonoBehaviour, IDisposable
    {
        private CompositeDisposable _disposables = new CompositeDisposable();
        // Current action state
        public ActionState CurrentState { get; private set; }
        // Events
        public Subject<Unit> OnActionStarted = new Subject<Unit>();
        public Subject<Unit> OnActionCompleted = new Subject<Unit>();
        public ReactiveProperty<ActionStateType> CurrentStateType = new ReactiveProperty<ActionStateType>();

        public ActionController()
        {
            // Initialize with an idle state
            //ChangeState(new IdleState());
        }
        public void ChangeState(ActionState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentStateType.Value = newState.Type;
            CurrentState.Enter();
            OnActionStarted.OnNext(Unit.Default);
        }
        public void Update()
        {
            CurrentState?.Update();
        }
        public void Dispose()
        {
            _disposables.Dispose();
            OnActionStarted.Dispose();
            OnActionCompleted.Dispose();
        }
    }
}