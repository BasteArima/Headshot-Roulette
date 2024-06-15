namespace _Project.Scripts.Runtime.State
{
    public interface IState
    {
        void Enter();
        void Execute();
        void Exit();
    }

}