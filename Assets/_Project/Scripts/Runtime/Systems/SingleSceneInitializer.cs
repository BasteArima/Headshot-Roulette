using UnityEngine;

namespace _Project.Scripts.Runtime.Systems
{
    public class SingleSceneInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _cameraStartPoint;

        private void Awake()
        {
            _camera.position = _cameraStartPoint.position;
            _camera.rotation = _cameraStartPoint.rotation;
        }
    }
}