﻿using System.Collections;
using UnityEngine;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        public GameObject projPrefab;
        public GameObject enemyAPrefab;
        public GameObject gameOverScreen;

        private Camera _cam;
        private float _repeatRate = 10.0f;
        private int difficultyLevel = 0;

        public bool isGameOver = false;
        
        // Start is called before the first frame update
        void Start()
        {
            _cam = Camera.main;
            
            InvokeRepeating(nameof(UpDifficulty), 0.0f, 30.0f);
            StartCoroutine(SpawnEnemy());

            gameOverScreen.SetActive(false);
        }
        
        // Speed of spawning, 1 every 10 seconds to start, up by 1 every 30 seconds
        

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var newProj = Instantiate(projPrefab, GameObject.Find("BulletStartPos").transform.position, Quaternion.identity);
                newProj.GetComponent<ProjectileController>().target = _cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Storage.BusHealth <= 0 && !isGameOver)
            {
                EndGame();
            }
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                Vector3 spawnPos = new Vector3(-10, Random.Range(-4.0f, 4.0f));
                Instantiate(enemyAPrefab, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(_repeatRate);
            }
        }

        void UpDifficulty()
        {
            difficultyLevel += 1;
            _repeatRate = 10.0f / difficultyLevel;
        }

        public void EndGame()
        {
            Debug.Log("GameOver");
            gameOverScreen.SetActive(true);
            isGameOver = true;
        }
    }
}
