using UnityEngine;

namespace _Project.Scripts.Runtime.State
{
    [System.Serializable]
    public abstract class State : MonoBehaviour, IState
    {
        protected Player _player;

        public virtual void Init(Player player)
        {
            _player = player;
        }

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }

}