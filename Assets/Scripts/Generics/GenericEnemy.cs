using UnityEngine;

namespace Generics
{
    [CreateAssetMenu]
    public class GenericEnemy : ScriptableObject
    {

        public float enemyHealth;
        public float enemySpeed;
        public string enemyType;
        public float attackSpeed;
        public Sprite sprite;

        public void SetEnemyHealth(float hp)
        {
            enemyHealth = hp;
        }

        public void SetEnemyType(string type)
        {
            enemyType = type;
        }

        public void SetEnemySpeed(float speed)
        {
            enemySpeed = speed;
        }

        public void SetAttackSpeed(float aS)
        {
            attackSpeed = aS;
        }

        public float GetAttackSpeed()
        {
            return attackSpeed;
        }

        public float GetEnemySpeed()
        {
            return enemySpeed;
        }

        public float GetEnemyHealth()
        {
            return enemyHealth;
        }

        public string GetEnemyType()
        {
            return enemyType;
        }
    }
}
