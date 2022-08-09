using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class Room : MonoBehaviour
    {
        public RoomType RoomType;
        public GameObject DoorD;
        public GameObject DoorU;
        public GameObject DoorR;
        public GameObject DoorL;
        [SerializeField] private GameObject[] RewardPrefabs;
        [SerializeField] private GameObject[] RegularPrefabs;
        [SerializeField] private GameObject[] ShopPrefabs;
        [SerializeField] private GameObject[] BossPrefabs;
        [SerializeField] private GameObject[] StartPrefabs;

        public int ConnectionCount;
        public int currentConnectionCount;

        private void Start()
        {
            switch (RoomType)
            {
                case RoomType.Regular:
                    Instantiate(RegularPrefabs[Random.Range(0, RegularPrefabs.Length)],transform);
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
        }
    }
}