using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.State
{
    public class CoreGameStateManager : MonoBehaviour
    {
        [SerializeField] private State[] _states;
        
        private bool _gameOver;
        
        public int RandomBulletPosition { get; private set; }
        public int CurrentShotTry { get; set; }
        public int CurrentPlayer { get; set; }
        
        [Button]
        public void StartGame()
        {
            Debug.Log($"Starting game");
            _gameOver = false;
            CurrentShotTry = 0;
            SetRandomBulletInWeapon();
            RandomFirstPlayer();
            StartGameCycle();
        }

        private async UniTask StartGameCycle()
        {
            if (_gameOver)
            {
                // In Game Over method
                return;
            }
            
            foreach (var state in _states)
            {
                if (_gameOver)
                {
                    // In Game Over method
                    break;
                }
                
                await state.Execute(this);
            }
            if(!_gameOver)
                StartGameCycle();
        }

        private void SetRandomBulletInWeapon()
        {
            RandomBulletPosition = Random.Range(0, 6);
            Debug.Log($"Start random bullet position: {RandomBulletPosition}");
        }

        private void RandomFirstPlayer()
        {
            CurrentPlayer = Random.Range(0, 2);
            Debug.Log($"Start random player: {CurrentPlayer}");
        }

        public void SetGameOver()
        {
            _gameOver = true;
        }
    }
}