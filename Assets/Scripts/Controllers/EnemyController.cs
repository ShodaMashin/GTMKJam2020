using Generics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class EnemyController : MonoBehaviour
    {
        public GenericEnemy enemyStats;

        private enum Phase
        {
            Move,
            Shoot
        }

        private Phase _currentPhase = Phase.Move;

        [FormerlySerializedAs("Health")] public float health;
        // Start is called before the first frame update
        void Start()
        {
            SpriteRenderer rend = GetComponent<SpriteRenderer>();
            rend.sprite = enemyStats.sprite;
        
            health = enemyStats.enemyHealth;
        }
        
        // While X<1.5, Move right. Stop at X=1.5 and Shoot at Bus
        
        public void DamageEnemy(int damage)
        {
            health -= damage;
        }

        // Update is called once per frame
        void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }

            if (_currentPhase == Phase.Move)
            {
                Vector2 vec2pos = transform.position;
                Vector2 targetPos = new Vector2(1.5f, vec2pos.y);
                float step = enemyStats.enemySpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(vec2pos, targetPos, step);

                if (vec2pos == targetPos)
                {
                    _currentPhase = Phase.Shoot;
                }
            } else if (_currentPhase == Phase.Shoot)
            {
                // Shooting code here
            }
        }
    }
}
