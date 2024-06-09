using UnityEngine;

namespace _Project.Scripts.Runtime
{
    public class ChangeCursorOnHover : MonoBehaviour
    {
        private CursorMode cursorMode = CursorMode.Auto;
        private Vector2 hotSpot = Vector2.zero;

        private void OnMouseEnter()
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}