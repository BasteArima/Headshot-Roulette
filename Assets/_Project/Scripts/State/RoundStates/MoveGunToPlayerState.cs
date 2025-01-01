using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.State.RoundStates
{
    public class MoveGunToPlayerState : State
    {
        [SerializeField] private Transform _gun;
        [SerializeField] private Transform _playerGunPosition;
        [SerializeField] private Animator _enemyAnimator;
        [SerializeField] private Transform _enemyGunPosition;
        [SerializeField] private float _moveGunDuration;
        [SerializeField] private float _waitForTryShoot;
        [SerializeField] private GameObject _tipToClickForPlayer;
        [SerializeField] private Transform _centerPoint;
        [SerializeField] private float _moveToCenterDuration = 1f;
        
        private bool _canShoot;
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        public override void OnEnter(StateManager stateManager)
        {
            _canShoot = false;
            var finalPosition = stateManager.SessionData.CurrentPlayer == 0 ? _playerGunPosition : _enemyGunPosition;
            
            _gun.DOMove(finalPosition.position, _moveGunDuration).SetEase(Ease.InOutQuad);
            _gun.DORotate(new Vector3(0, 90, 0), _moveGunDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    StartCoroutine(WaitUntilClick(stateManager));
                });
        }
        
        public override void OnUpdate(StateManager stateManager)
        {
            if (!_canShoot) return;
            
            if (stateManager.SessionData.CurrentPlayer == 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _canShoot = false;
                    _tipToClickForPlayer.SetActive(false);
                    _isComplete = true;
                }
            }
        }

        private IEnumerator WaitUntilClick(StateManager stateManager)
        {
            yield return new WaitForSeconds(_waitForTryShoot);
            _canShoot = true;
            if (stateManager.SessionData.CurrentPlayer == 1)
                _isComplete = true;
            else
                _tipToClickForPlayer.SetActive(true);
        }

        public override void OnExit(StateManager stateManager)
        {
            _isComplete = false;
            _canShoot = false;
            _tipToClickForPlayer.SetActive(false);
        }
    }
}