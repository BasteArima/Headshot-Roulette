using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Core
{
    public class GameContext
    {
        public Player[] Players { get; }
        public Player CurrentPlayer{ get; set; }
        public int RoundNumber { get; set; }
    }
}