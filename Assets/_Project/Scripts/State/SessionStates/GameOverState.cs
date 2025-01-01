using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.State.SessionStates
{
    public class GameOverState : State
    {
        [SerializeField] private GameObject _gameOverTitle;
        [SerializeField] private Button _restartButton;
        
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        private void Awake()
        {
            _restartButton.onClick.AddListener(() => _isComplete = true);
        }

        public override void OnEnter(StateManager stateManager)
        {
            _gameOverTitle.SetActive(true);
        }

        public override void OnUpdate(StateManager stateManager)
        {
        }

        public override void OnExit(StateManager stateManager)
        {
            _isComplete = false;
        }
    }
}