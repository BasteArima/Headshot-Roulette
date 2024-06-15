using UnityEngine;
using Zenject;

namespace _Project.Scripts.Runtime.Systems
{
    public class SinglePlayerAISimulator : MonoBehaviour
    {
        [SerializeField] private Player _aiPlayer;

        [Inject] private PlayerGameJoinHandler _playerGameJoinHandler;

        private void Start()
        {
            _playerGameJoinHandler.AiJoin(_aiPlayer);
        }
    }
}