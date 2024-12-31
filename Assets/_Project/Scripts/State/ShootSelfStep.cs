using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.State
{
    [CreateAssetMenu(menuName = "State/ShootSelfStep")]
    public class ShootSelfStep : State
    {
        public override UniTask Execute(CoreGameStateManager coreGameStateManager)
        {
            Debug.Log($"Shot");
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
            
            return UniTask.CompletedTask;
        }
    }
}