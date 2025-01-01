using UnityEngine;

namespace _Project.Scripts.State.RoundStates
{
    public class OtherPlayerTurnState : State
    {
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        public override void OnEnter(StateManager stateManager)
        {
            stateManager.SessionData.ToggleCurrentPlayer();
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