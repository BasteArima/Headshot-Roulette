using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.State.RoundStates
{
    public class ShootSelfStep : State
    {
        [SerializeField] private Transform _gun;
        [SerializeField] private Transform _centerPoint;
        [SerializeField] private float _moveToCenterDuration;
        
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        public override void OnEnter(StateManager stateManager)
        {
            if (stateManager.SessionData.RandomBulletPosition == stateManager.SessionData.CurrentShotTry)
            {
                stateManager.SessionData.SetGameOver();
                _isComplete = true;
            }
            else
            {
                stateManager.SessionData.CurrentShotTry++;
                StartCoroutine(MoveGunToTable());
            }
        }

        private IEnumerator MoveGunToTable()
        {
            yield return new WaitForSeconds(0.5f);
            
            _gun.DOMove(_centerPoint.position, _moveToCenterDuration).SetEase(Ease.InOutQuad);
            _gun.DOLocalRotate(new Vector3(0, 0, -90f), _moveToCenterDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    _isComplete = true;
                });
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