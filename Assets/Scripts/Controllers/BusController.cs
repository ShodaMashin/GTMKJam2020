using UnityEngine;

namespace Controllers
{
    public class BusController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            var busHolder = GameObject.Find("BusCannon");
            if (Camera.main == null) return;
            var mouse = Input.mousePosition;
            var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
            var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            busHolder.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        }

        public void DamageBus(int damage)
        {
            Storage.BusHealth -= damage;
        }
    }
}
