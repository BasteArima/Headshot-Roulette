using UnityEngine;

namespace _Project.Scripts.Runtime
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Material _fireMaterial;
        [SerializeField] private Material _blankMaterial;

        private MeshRenderer _meshRenderer;
        
        public bool IsFire { get; private set; }

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetBulletType(bool fire)
        {
            _meshRenderer.material = fire ? _fireMaterial : _blankMaterial;
        }
    }
}