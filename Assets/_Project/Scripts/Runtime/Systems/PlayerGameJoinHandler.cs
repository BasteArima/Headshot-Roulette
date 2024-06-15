using System;
using UnityEngine;

namespace _Project.Scripts.Runtime.Systems
{
    public class PlayerGameJoinHandler : MonoBehaviour
    {
        public event Action<Player, Player> AllPlayerJoined; 

        private Player _playerOne;
        private Player _playerTwo;
        
        public void Join(Player player)
        {
            if (null == _playerOne)
                _playerOne = player;
            else if (null == _playerTwo)
                _playerTwo = player;
            else
                return;

            TryStartGame();
        }

        public void AiJoin(Player player)
        {
            if (null == _playerTwo)
                _playerTwo = player;
        }

        private void TryStartGame()
        {
            if (null != _playerOne && null != _playerTwo)
                AllPlayerJoined?.Invoke(_playerOne, _playerTwo);
        }
    }
}