using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.MirrorRuntime
{
    public class Player : NetworkBehaviour
    {
        [SerializeField] private GameObject _applePrefab;
        [SerializeField] private int _money;

        private GameManager _gameManager;
        private Camera _camera;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            _camera = Camera.main;
            _gameManager = FindAnyObjectByType<GameManager>();
        }
        
        private void Update()
        {
            if (!isLocalPlayer) return;

            if (isOwned)
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                float speed = 5f * Time.deltaTime;
                transform.Translate(new Vector2(h * speed, v * speed));

                CameraMovement();

                if (Input.GetKeyDown(KeyCode.E))
                    CmdSpawnApple();
            }
        }

        private void CameraMovement()
        {
            _camera.transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1f);
        }
        
        [Command]
        private void CmdSpawnApple()
        {
            var prefab = Instantiate(_applePrefab, Random.insideUnitCircle * 5, Quaternion.identity);
            NetworkServer.Spawn(prefab);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<Money>())
            {
                Destroy(col.gameObject);
                _money++;
                _gameManager.SetLocalMoneyView(_money);
                RpcGlobalMoney();
            }
        }

        [ClientRpc]
        public void RpcGlobalMoney()
        {
            _gameManager.AddGameMoney(1);
        }
    }
}