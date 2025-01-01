using UnityEngine;

namespace _Project.Scripts.State.SessionStates
{
    public class SetStartOptionsState : State
    {
        [SerializeField] private GameObject _gameOverTitle;
        [SerializeField] private Transform _gun;
        [SerializeField] private Transform _gunHandPosition;
        
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        public override void OnEnter(StateManager stateManager)
        {
            _gameOverTitle.SetActive(false);
            _gun.position = _gunHandPosition.position;
            _gun.rotation = _gunHandPosition.rotation;
            stateManager.SessionData.SetStartOptions();
            _isComplete = true;
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