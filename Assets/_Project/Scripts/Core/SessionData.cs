using _Project.Scripts.Signals;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Core
{
    [System.Serializable]
    public class SessionData
    {
        [ShowInInspector, ReadOnly] public int RandomBulletPosition { get; private set; }
        [ShowInInspector, ReadOnly] public int CurrentShotTry { get; set; }
        [ShowInInspector, ReadOnly] public int CurrentPlayer { get; set; }
        [ShowInInspector, ReadOnly] public bool GameOver { get; private set; }
        
        public void SetStartOptions()
        {
            GameOver = false;
            CurrentShotTry = 0;
            RandomBulletPosition = Random.Range(0, 6);
        }

        public void ToggleCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == 0 ? 1 : 0;
        }

        public void SetGameOver()
        {
            GameOver = true;
            MessageBroker.Default.Publish(new RoundGameOverSignal());
        }
    }
}