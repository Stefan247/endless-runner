﻿using System;
using GMScripts;
using MiscScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerScoreScript : MonoBehaviour
    {
        public ScoreScript scoreHandler;
        public ZombieSpawnScript zombieHandler;
        public TowerAttack towerHandler;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Food") || other.gameObject.CompareTag("GoodFood"))
            {
                scoreHandler.UpdateScore(other.gameObject);
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("Food"))
            {
                zombieHandler.SpawnZombies();
            }

            if (other.gameObject.CompareTag("GoodFood"))
            {
                towerHandler.AddPizza();
            }

            if (other.gameObject.CompareTag("Box"))
            {
                scoreHandler.UpdateHp(-1);
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("Heart"))
            {
                scoreHandler.UpdateHp(1);
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("Coin"))
            {
                scoreHandler.UpdateScore(other.gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}
