using _Project.Scripts.State.Interfaces;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.State
{
    public class StateMachine<T> where T : class
    {
        private T _context;
        private IState<T> _currentState;

        public async UniTask SwitchState(IState<T> newState)
        {
            if (_currentState != null)
                await _currentState.Exit(_context);
        
            _currentState = newState;
            await _currentState.Enter(_context);
        }
    }
}