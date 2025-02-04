using _Project.Scripts.Signals;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.State.SessionStates
{
    public class PlayersShotsState : State
    {
        [SerializeField] private RoundStatesManager _roundStatesManager;
        
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        private void Awake()
        {
            MessageBroker.Default
                .Receive<RoundGameOverSignal>()
                .Subscribe(RoundStatesManagerOnRestartRound)
                .AddTo(gameObject);
        }
        
        public override void OnEnter(StateManager stateManager)
        {
            _roundStatesManager.StartRound();
        }

        private void RoundStatesManagerOnRestartRound(RoundGameOverSignal signal)
        {
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