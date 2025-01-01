using UnityEngine;

namespace _Project.Scripts.State
{
    public abstract class State : MonoBehaviour
    {
        /// <summary>
        /// Флаг, что состояние завершило свою работу
        /// </summary>
        public abstract bool IsComplete { get; }

        /// <summary>
        /// Вызывается один раз при входе в состояние
        /// </summary>
        public abstract void OnEnter(StateManager stateManager);

        /// <summary>
        /// Вызывается каждый кадр, пока состояние активно
        /// </summary>
        public abstract void OnUpdate(StateManager stateManager);

        /// <summary>
        /// Вызывается один раз перед выходом из состояния
        /// </summary>
        public abstract void OnExit(StateManager stateManager);
    }
}