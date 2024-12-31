using UnityEngine;

namespace _Project.Scripts.State
{
    public class OtherPlayerTurnState : State
    {
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        public override void OnEnter(CoreGameStateManager coreGameStateManager)
        {
            coreGameStateManager.ToggleCurrentPlayer();
            Debug.Log($"Now turn to {coreGameStateManager.CurrentPlayer} player");
            _isComplete = true;
        }

        public override void OnUpdate(CoreGameStateManager coreGameStateManager)
        {
        }

        public override void OnExit(CoreGameStateManager coreGameStateManager)
        {
        }
    }
}