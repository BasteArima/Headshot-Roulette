using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Runtime
{
    public class CheatPanel : MonoBehaviour
    {
        [SerializeField] private bool _enable;
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _tablePoint;
        
        void OnGUI()
        {
            if (!_enable) return;
            if (GUILayout.Button("Fast table")){ 
                _camera.transform.DOMove(_tablePoint.position, 0);
                _camera.transform.DORotate(_tablePoint.rotation.eulerAngles, 0);
            }
        }
    }
}