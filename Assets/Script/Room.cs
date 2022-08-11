using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class Room : MonoBehaviour
    {
        private RoomEventHandler _roomEventHandler;
        public RoomType RoomType;
        public Door DoorD;
        public Door DoorU;
        public Door DoorR;
        public Door DoorL;
        [SerializeField] private GameObject[] RewardPrefabs;
        [SerializeField] private GameObject[] RegularPrefabs;
        [SerializeField] private GameObject[] ShopPrefabs;
        [SerializeField] private GameObject[] BossPrefabs;
        [SerializeField] private GameObject[] StartPrefabs;
        [SerializeField] private List<EnemyBehavior> activeEnemys;
        [SerializeField] private EnemyBehavior[] enemys;
        [SerializeField] private int maxWaves;
        private int currentWave = 1;
        private bool isCleared;
        public int ConnectionCount;
        public int currentConnectionCount;
        private Door[] _doors;

        [SerializeField] private bool isLockable;

        private void Start()
        {
            _doors = new[] { DoorR,DoorD,DoorL,DoorU };
            _roomEventHandler = GetComponent<RoomEventHandler>();
            switch (RoomType)
            {
                case RoomType.Regular:
                    Instantiate(RegularPrefabs[Random.Range(0, RegularPrefabs.Length)],transform);
                    isLockable = true;
                    break;
                case RoomType.Reward:
                    Instantiate(RewardPrefabs[Random.Range(0, RegularPrefabs.Length)],transform);
                    break;
                case RoomType.Boss:
                    Instantiate(BossPrefabs[Random.Range(0, RegularPrefabs.Length)],transform);
                    break;
                case RoomType.Shop:
                    Instantiate(ShopPrefabs[Random.Range(0, RegularPrefabs.Length)],transform);
                    break;
                case RoomType.Start:
                    Instantiate(StartPrefabs[Random.Range(0, RegularPrefabs.Length)],transform);
                    break;
            }

            foreach (var door in _doors)
            {
                door.isLockable = isLockable;
            }
            
            _roomEventHandler.OnEnemyDead += CheckWave;
        }

        public void Lock(bool isLock)
        {
            if (isCleared)
            {
               LockDoors(false);
            }
            else
            {
                LockDoors(true);
            }
            InstantiateEnemys();
            
            StartWave();
        }

        void LockDoors(bool isLock)
        {
            foreach (var door in _doors)
            {
                door.isLockable = false;
                if (door.isActive)
                {
                    door.Lock(isLock);
                }
            }
        }

        void StartWave()
        {
            if (!isCleared)
            {
                if (currentWave >= maxWaves)
                { 
                    isCleared = true;
                    Lock(false); 
                    return;
                } 
                currentWave++;
                for (int i = 0; i < activeEnemys.Count; i++) 
                    activeEnemys[i].isActive = true;
            }
        }
       

        void CheckWave()
        {
            Debug.Log(activeEnemys.Count);
            activeEnemys.RemoveAt(activeEnemys.Count-1);
            if (activeEnemys.Count != 0) return;
            if (activeEnemys.Count == 0)
            { 
                InstantiateEnemys();
                StartWave();
            }
        }

        void InstantiateEnemys()
        {
            int enemyCount = Random.Range(6, 10);
            for (int i = 0; i < enemyCount; i++)
            {
                int enemyIndex = Random.Range(0, enemys.Length);
                var newEnemy = Instantiate(enemys[enemyIndex],transform);
                newEnemy.transform.localPosition = Vector3.zero;
                activeEnemys.Add(newEnemy);
            }
        }
    }
}