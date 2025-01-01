namespace _Project.Scripts.State.RoundStates
{
    public class CheckGameOverState : State
    {
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        public override void OnEnter(StateManager stateManager)
        {
            _isComplete = !stateManager.SessionData.GameOver;
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