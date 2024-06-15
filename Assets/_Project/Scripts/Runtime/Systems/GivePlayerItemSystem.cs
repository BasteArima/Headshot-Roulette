using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Runtime.Systems
{
    public class GivePlayerItemSystem : MonoBehaviour
    {
        [SerializeField] private Dictionary<int, int> _itemsForRound;

        public int GetItemCountForThisRound()
        {
            return 0;
        }
    }
}