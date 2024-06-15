using _Project.Scripts.Runtime.Interactables;
using UnityEngine;

namespace _Project.Scripts.Runtime.Items
{
    public class Item : MonoBehaviour, IClickable
    {
        private Player _owner;

        public void Init(Player owner)
        {
            _owner = owner;
        }


        public void OnClick()
        {
        }
    }
}