using UnityEngine;

namespace _Project.Scripts.State
{
    public class ShootSelfStep : State
    {
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        public override void OnEnter(CoreGameStateManager coreGameStateManager)
        {
            if (coreGameStateManager.RandomBulletPosition == coreGameStateManager.CurrentShotTry)
            {
                Debug.Log($"Player: {coreGameStateManager.CurrentPlayer} shoot himself");
                coreGameStateManager.SetGameOver();
            }
            else
            {
                Debug.Log($"Player: {coreGameStateManager.CurrentPlayer} dodge bullet");
                coreGameStateManager.CurrentShotTry++;
            }
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