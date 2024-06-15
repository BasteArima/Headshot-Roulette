using Mirror;
using UnityEngine;

namespace _Project.Scripts.MirrorRuntime
{
    public class Player : NetworkBehaviour //даем системе понять, что это сетевой объект
    {
        private Camera _camera;
        
        private void Awake()
        {
            Application.targetFrameRate = 60;
            _camera = Camera.main;
        }

        void Update()
        {
            if (!isLocalPlayer) return;
            
            if (isOwned) //проверяем, есть ли у нас права изменять этот объект
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                float speed = 5f * Time.deltaTime;
                transform.Translate(new Vector2(h * speed, v * speed)); //делаем простейшее движение

                CameraMovement();
            }
        }

        private void CameraMovement()
        {
            _camera.transform.localPosition = new Vector3(transform.position.x, transform.position.y, -1f);
            //transform.position = Vector2.MoveTowards(transform.position, _camera.transform.localPosition, Time.deltaTime);
        }
    }
}