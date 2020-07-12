using UnityEngine;

namespace Controllers
{
    public class ProjectileController : MonoBehaviour
    {
        public Vector2 target;
        public float speed;

        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 vec2Pos = transform.position;
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(vec2Pos, target, step);
            if (vec2Pos == target)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("PlayerProj"))
            {
                other.gameObject.GetComponent<EnemyController>().DamageEnemy(100);
                Destroy(gameObject);
            } else if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("EnemyProj"))
            {
                other.gameObject.GetComponent<BusController>().DamageBus(1);
                Destroy(gameObject);
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
