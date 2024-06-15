using NaughtyAttributes;
using UnityEngine;

namespace _Project.Scripts.Runtime.Systems
{
    public class AmmoSpawnSystem : MonoBehaviour
    {
        [SerializeField] private Bullet[] _ammos;
        [SerializeField] private int _minAmmo;
        [SerializeField] private int _maxAmmo;

        private GameObject[] _spawnedAmmo;
        
        [Button]
        public void RandomAmmo()
        {
            foreach (var meshRenderer in _ammos)
                meshRenderer.gameObject.SetActive(false);
            
            var randomAmmoCount = Random.Range(_minAmmo, _maxAmmo + 1);
            int halfAmmo = randomAmmoCount / 2;

            // Создаём массив для хранения индексов пуль
            int[] ammoIndices = new int[randomAmmoCount];
            for (int i = 0; i < randomAmmoCount; i++)
            {
                ammoIndices[i] = i;
            }

            // Перемешиваем массив индексов
            for (int i = ammoIndices.Length - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (ammoIndices[i], ammoIndices[j]) = (ammoIndices[j], ammoIndices[i]);
            }

            // Активируем пули и задаём тип в случайном порядке
            for (int i = 0; i < randomAmmoCount; i++)
            {
                int index = ammoIndices[i];
                _ammos[index].gameObject.SetActive(true);
                _ammos[index].SetBulletType(i >= halfAmmo);
            }
        }
    }
}