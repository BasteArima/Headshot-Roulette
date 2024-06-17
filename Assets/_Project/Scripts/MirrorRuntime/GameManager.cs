using Mirror;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.MirrorRuntime
{
    public class GameManager : NetworkBehaviour
    {
        [SyncVar]
        private int _gameMoney;
        
        [SerializeField] private TMP_Text _globalMoney;
        [SerializeField] private TMP_Text _money;

        public void StopGame()
        {
            if(NetworkServer.active && NetworkClient.isConnected)
                NetworkManager.singleton.StopHost();
            else if(NetworkClient.isConnected)
                NetworkManager.singleton.StopClient();
            else if(NetworkServer.active)
                NetworkManager.singleton.StopServer();
        }

        public void AddGameMoney(int amount)
        {
            _gameMoney += amount;
            _globalMoney.text = "Global Money: " + _gameMoney;
        }
        
        public void SetLocalMoneyView(int amount)
        {
            _money.text = "Money: " + amount;
        }
    }
}