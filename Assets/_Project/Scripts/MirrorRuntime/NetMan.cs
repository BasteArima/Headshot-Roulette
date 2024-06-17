using Mirror;
using UnityEngine;

namespace _Project.Scripts.MirrorRuntime
{
    public class NetMan : NetworkManager
    {
        [SerializeField] private string _customNetworkAddress;
        
        public void ConnectToServer()
        {
            networkAddress = _customNetworkAddress;
            StartClient();
        }
    }
}