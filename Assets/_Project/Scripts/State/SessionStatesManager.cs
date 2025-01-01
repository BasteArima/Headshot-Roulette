using _Project.Scripts.Signals;
using UniRx;

namespace _Project.Scripts.State
{
    public class SessionStatesManager : StateManager
    {
        private void Awake()
        {
            MessageBroker.Default
                .Receive<StartCoreGameSignal>()
                .Subscribe(StartSession)
                .AddTo(gameObject); 
        }

        private void StartSession(StartCoreGameSignal signal)
        {
            RestartStatesFromZero();
        }
    }
}