using _Project.Scripts.Runtime.Systems;
using UnityEngine;

namespace _Project.Scripts.Runtime.State
{
    public class GiveItemsStep : State
    {
        [SerializeField] private GivePlayerItemSystem _givePlayerItemSystem;
        
        public override void Enter()
        {
            var itemsCount = _givePlayerItemSystem.GetItemCountForThisRound();
            if (itemsCount > 0)
            {
                // заспавнить айтем, разложить, наверное тут какой-то метод с рекурсией будет мб
                Debug.Log($"Items more than 0");
            }
            else
            {
                // next
            }
        }

        public override void Execute()
        {
        }

        public override void Exit()
        {
        }
    }
}