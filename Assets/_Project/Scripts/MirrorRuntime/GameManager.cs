using Mirror;
using UnityEngine;

namespace _Project.Scripts.MirrorRuntime
{
    public class GameManager : MonoBehaviour
    {
        public void StopGame()
        {
            if(NetworkServer.active && NetworkClient.isConnected)
                NetworkManager.singleton.StopHost();
            else if(NetworkClient.isConnected)
                NetworkManager.singleton.StopClient();
            else if(NetworkServer.active)
                NetworkManager.singleton.StopServer();
        }
    }
}