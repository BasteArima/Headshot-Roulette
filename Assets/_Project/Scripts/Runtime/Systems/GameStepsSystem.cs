using UnityEngine;
using Zenject;

namespace _Project.Scripts.Runtime.Systems
{
    public class GameStepsSystem : MonoBehaviour
    {
        [Inject] private PlayerGameJoinHandler _playerGameJoinHandler;

        private Player _currentPlayerStep;
        
        private void Start()
        {
            _playerGameJoinHandler.AllPlayerJoined += OnAllPlayerJoined;
        }

        private void OnDestroy()
        {
            _playerGameJoinHandler.AllPlayerJoined -= OnAllPlayerJoined;
        }

        private void OnAllPlayerJoined(Player playerOne, Player playerTwo)
        {
            if (playerTwo.IsBot)
            {
                _currentPlayerStep = playerOne;
            }
            else
            {
                var rndPlayerNum = Random.Range(0, 1);
                _currentPlayerStep = rndPlayerNum == 0 ? playerOne : playerTwo;
            }
        }
    }
}