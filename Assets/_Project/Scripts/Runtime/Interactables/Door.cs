using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace _Project.Scripts.Runtime.Interactables
{
    public class Door : MonoBehaviour, IClickable
    {
        [Header("Door settings")]
        [SerializeField] private Transform _doorPivot;
        [SerializeField] private float _doorRotate;
        [SerializeField] private float _doorOpenDuration;
        
        [Header("Camera settings")]
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _cameraFinalPoint;
        [SerializeField] private float _moveCameraDuration;
        [SerializeField] private float _moveRotateCameraDuration;
        
        [Button()]
        public void OnClick()
        {
            var seq = DOTween.Sequence();
            seq.Append(_doorPivot.DORotate(new Vector3(0,_doorRotate, 0), _doorOpenDuration));
            seq.Append(_camera.DOMove(_cameraFinalPoint.position, _moveCameraDuration));
            seq.Append(_camera.DORotate(_cameraFinalPoint.rotation.eulerAngles, _moveRotateCameraDuration));
        }
    }
}