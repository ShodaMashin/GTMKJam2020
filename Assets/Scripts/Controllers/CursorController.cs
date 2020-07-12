using UnityEditor.Animations;
using UnityEngine;

namespace Controllers
{
    public class CursorController : MonoBehaviour
    {
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        
        // Start is called before the first frame update
        void Start()
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void SetCursorTarget()
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

        public void SetCursorDefault()
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }
}
