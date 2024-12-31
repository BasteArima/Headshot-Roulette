using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.State
{
    [CreateAssetMenu(menuName = "State/OtherPlayerTurnState")]
    public class OtherPlayerTurnState : State
    {
        public override UniTask Execute(CoreGameStateManager coreGameStateManager)
        {
            coreGameStateManager.CurrentPlayer = coreGameStateManager.CurrentPlayer == 0 ? 1 : 0;
            Debug.Log($"Now turn to {coreGameStateManager.CurrentPlayer} player");
            return UniTask.CompletedTask;
        }
    }
}