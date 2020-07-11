using UnityEngine;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        public GameObject projPrefab;
        public GameObject enemyAPrefab;

        private Camera cam;
        
        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var newProj = Instantiate(projPrefab, GameObject.Find("BulletStartPos").transform.position, Quaternion.identity);
                projPrefab.GetComponent<ProjectileController>().target = cam.ScreenToWorldPoint(Input.mousePosition);
            }


            if (Input.GetKeyDown(KeyCode.K))
            {
                Vector3 spawnPos = new Vector3(-10, Random.Range(4.0f, -4.0f));
                Instantiate(enemyAPrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}
