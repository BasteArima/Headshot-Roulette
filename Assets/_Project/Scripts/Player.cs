using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private string _nickname;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHealth;
        
        [field: SerializeField] public bool IsBot { get; private set; }
    }
}