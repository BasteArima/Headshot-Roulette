using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Playables;

namespace _Project.Scripts.State.SessionStates
{
    public class LoadGunState : State
    {
        [SerializeField] private PlayableDirector _loadGunPlayableDirector;
        [SerializeField] private Transform _gun;
        [SerializeField] private Transform _centerPoint;
        [SerializeField] private float _moveToCenterDuration = 1f;
        [SerializeField] private float _rollDuration = 3f;
        [SerializeField] private float _rollSpeed = 4f;

        private StateManager _gameStateManager;
        private bool _isComplete;

        public override bool IsComplete => _isComplete;

        public override void OnEnter(StateManager stateManager)
        {
            _gameStateManager = stateManager;
            _loadGunPlayableDirector.Play();
        }

        public override void OnUpdate(StateManager stateManager)
        {
        }

        public override void OnExit(StateManager stateManager)
        {
            _isComplete = false;
        }

        [Button]
        private void RerollGun()
        {
            var randomPlayer = Random.Range(0, 2);
            var targetAngle = randomPlayer == 0 ? 0 : 180;

            _gun.DOLocalRotate(new Vector3(_gun.localRotation.eulerAngles.x, 360 * _rollSpeed + targetAngle, _gun.localRotation.eulerAngles.z), _rollDuration,
                    RotateMode.FastBeyond360)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    _gameStateManager.SessionData.CurrentPlayer = randomPlayer;
                    _isComplete = true;
                });
        }

        public void MoveGunToCenterAndRoll()
        {
            _gun.DOMove(_centerPoint.position, _moveToCenterDuration).SetEase(Ease.InOutQuad).OnComplete(RerollGun);
        }
    }
}