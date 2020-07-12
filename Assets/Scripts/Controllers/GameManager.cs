﻿using System;
using System.Collections;
using System.Diagnostics.Contracts;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        public GameObject projPrefab;
        public GameObject enemyAPrefab;
        public GameObject coffeeScene;
        public GameObject cursorObject;

        public Button sceneSwitchButton;
        
        private Camera _cam;
        private float _repeatRate = 10.0f;
        private int difficultyLevel = 0;
        
        
        // Start is called before the first frame update
        void Start()
        {
            _cam = Camera.main;
            
            InvokeRepeating(nameof(UpDifficulty), 0.0f, 30.0f);
            StartCoroutine(SpawnEnemy());
            
            sceneSwitchButton.onClick.AddListener(SceneSwitch);
        }
        
        // Speed of spawning, 1 every 10 seconds to start, up by 1 every 30 seconds
        

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && Storage.CurrentGameState == Storage.GameState.Bus)
            {
                var newProj = Instantiate(projPrefab, GameObject.Find("BulletStartPos").transform.position, Quaternion.identity);
                newProj.GetComponent<ProjectileController>().target = _cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                Vector3 spawnPos = new Vector3(-10, Random.Range(-4.0f, 3.0f));
                Instantiate(enemyAPrefab, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(_repeatRate);
            }
        }

        void UpDifficulty()
        {
            difficultyLevel += 1;
            _repeatRate = 10.0f / difficultyLevel;
        }

        void SceneSwitch()
        {
            switch (Storage.CurrentGameState)
            {
                case Storage.GameState.Bus:
                    coffeeScene.SetActive(true);
                    Storage.CurrentGameState = Storage.GameState.Coffee;
                    cursorObject.GetComponent<CursorController>().SetCursorDefault();
                    break;
                case Storage.GameState.Coffee:
                    coffeeScene.SetActive(false);
                    Storage.CurrentGameState = Storage.GameState.Bus;
                    cursorObject.GetComponent<CursorController>().SetCursorTarget();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
