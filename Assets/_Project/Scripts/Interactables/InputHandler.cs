using UnityEngine;

namespace _Project.Scripts.Interactables
{
    public class InputHandler : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                HandleClick(Input.mousePosition);

            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                    HandleClick(touch.position);
            }
        }

        private void HandleClick(Vector3 position)
        {
            var ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var hitObject = hit.collider.gameObject;
                var clickable = hitObject.GetComponent<IClickable>();
                if (null != clickable)
                    clickable.OnClick();            }
        }
    }
}