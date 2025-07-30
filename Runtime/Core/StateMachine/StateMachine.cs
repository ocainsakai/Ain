namespace Ain
{
    using System.Collections.Generic;
    using UnityEngine;
    public abstract class StateMachine<T> : MonoBehaviour where T : IState
    {
        protected readonly List<IState> _states = new();
        public IReadOnlyList<IState> States => _states.AsReadOnly();
        
        protected IState _currentState;
        public IState CurrentState => _currentState;
        public virtual void AddState(IState state)
        {
            _states.Add(state);
        }
        public virtual void SetInitialState(IState state)
        {
            _currentState = state;
            _currentState.OnEnter();
        }
        public virtual void Tick()
        {
            if (_currentState != null)
            {
                _currentState.Tick();
            }
        }
        public virtual void ChangeState(IState newState)
        {
            if (_currentState != null)
            {
                _currentState.OnExit();
            }
            _currentState = newState;
            _currentState.OnEnter();
        }
    }
}