﻿using UnityEngine;

namespace GMScripts
{
    public class FoodSpawningScript : MonoBehaviour
    {
        public Transform[] spawnPoints;
        public Rigidbody[] collectibles;
        
        public float foodSpeed = 100f;
        public float foodRepeatRate = 1f;
        public float speedRepeatRate = 10f;
        
        private void Start()
        {
            InvokeRepeating(nameof(SpawnHandler), 2f, foodRepeatRate);
            InvokeRepeating(nameof(SpeedHandler), 10f, speedRepeatRate);
        }
        
        private void SpawnHandler()
        {
            Invoke(nameof(SpawnFoodHandler), 0f);
        }

        private void SpeedHandler()
        {
            foodSpeed += 5f;
        }

        private void SpawnFoodHandler()
        {
            int freeSpace = Random.Range(0, 2);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i != freeSpace)
                {
                    Rigidbody collectible = Instantiate(collectibles[Random.Range(0, collectibles.Length)],
                        spawnPoints[i].position, Quaternion.identity);
                    collectible.AddForce(0f, 0f, -foodSpeed);
                }
            }
        }
    }
}