using System.Collections;
using Generics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class EnemyController : MonoBehaviour
    {
        public GenericEnemy enemyStats;
        public GameObject enemyProjPrefab; 

        private enum Phase
        {
            Move,
            Shoot,
            Shooting
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
        
        // While X<1.5, Move right. Stop at X=1.5 and Shoot at Bus every 3? seconds
        
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
                StartCoroutine(AttackBus());
                _currentPhase = Phase.Shooting;
            }
        }

        private IEnumerator AttackBus()
        {    
            while (true)
            {
                var newProj = Instantiate(enemyProjPrefab, gameObject.transform.position, Quaternion.identity);
                enemyProjPrefab.GetComponent<ProjectileController>().target = GameObject.Find("Bus").transform.position;
                yield return new WaitForSeconds(enemyStats.attackSpeed);
            }
        }
    }
}
