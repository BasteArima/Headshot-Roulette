using _Project.Scripts.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.State
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] protected State[] _states;
        [SerializeField] private SessionData _sessionData = new SessionData();

        [ShowInInspector, ReadOnly] private State _currentState;
        [ShowInInspector, ReadOnly] private int _currentStateIndex = -1;

        public SessionData SessionData => _sessionData;

        private void Update()
        {
            if (null == _currentState)
                return;

            if (!_currentState.IsComplete)
                _currentState.OnUpdate(this);
            else
                GoToNextState();
        }

        private void GoToState(int index)
        {
            if (null != _currentState)
                _currentState.OnExit(this);

            if (index < 0 || index >= _states.Length)
            {
                _currentState = null;
                RestartStatesFromZero();
                return;
            }

            _currentStateIndex = index;
            _currentState = _states[_currentStateIndex];

            _currentState.OnEnter(this);
        }

        private void GoToNextState()
        {
            GoToState(_currentStateIndex + 1);
        }

        protected void RestartStatesFromZero()
        {
            GoToState(0);
        }
    }
}