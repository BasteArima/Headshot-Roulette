using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.State
{
    public abstract class State : ScriptableObject
    {
        public abstract UniTask Execute(CoreGameStateManager coreGameStateManager);
    }
}