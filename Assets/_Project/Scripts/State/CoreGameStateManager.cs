using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.State
{
    public class CoreGameStateManager : MonoBehaviour
    {
        public event Action GameOverEvent;
        
        [SerializeField] private State[] _states;
        
        private State _currentState;
        private int _currentStateIndex = -1;
        private bool _gameOver;
        
        public int RandomBulletPosition { get; private set; }
        public int CurrentShotTry { get; set; }
        public int CurrentPlayer { get; private set; }
        
        [Button]
        public void StartGame()
        {
            if (_states.Length== 0)
            {
                Debug.LogError("[CoreGameStateManager] Не заданы стейты в инспекторе!");
                return;
            }

            Debug.Log($"Starting game");
            _gameOver = false;
            CurrentShotTry = 0;
            _currentStateIndex = -1;
            SetStartRandomOptions();
            GoToState(0);
        }

        private void SetStartRandomOptions()
        {
            RandomBulletPosition = Random.Range(0, 6);
            CurrentPlayer = Random.Range(0, 2);
            Debug.Log($"Start random bullet position: {RandomBulletPosition}");
            Debug.Log($"Start random player: {CurrentPlayer}");
        }
        
        private void Update()
        {
            if (_currentState == null)
                return;

            if (!_currentState.IsComplete)
            {
                _currentState.OnUpdate(this);
            }
            else
            {
                if (_gameOver)
                    return;
                
                GoToNextState();
            }
        }
        
        private void GoToState(int index)
        {
            if (_currentState != null)
                _currentState.OnExit(this);

            if (index < 0 || index >= _states.Length)
            {
                Debug.Log("[CoreGameStateManager] Restart states");
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

        private void RestartStatesFromZero()
        {
            GoToState(0);
        }

        public void SetGameOver()
        {
            _gameOver = true;
            GameOverEvent?.Invoke();
        }

        public void ToggleCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == 0 ? 1 : 0;
        }
    }
}