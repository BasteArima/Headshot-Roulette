using Cysharp.Threading.Tasks;

namespace _Project.Scripts.State.Interfaces
{
    public interface IState<T> where T : class
    {
        UniTask Enter(T context);
        UniTask Update(T context);
        UniTask Exit(T context);
    }
}