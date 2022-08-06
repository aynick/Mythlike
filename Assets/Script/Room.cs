using System;
using UnityEngine;

namespace Script
{
    public class Room : MonoBehaviour
    {
        public RoomType RoomType;
        public GameObject DoorD;
        public GameObject DoorU;
        public GameObject DoorR;
        public GameObject DoorL;

        public void RotateRandomly()
        {
            var DoorDown = DoorD;
            DoorD = DoorU;
            DoorU = DoorDown;
            var DoorRight = DoorR;
            DoorR = DoorL;
            DoorL = DoorRight;
        }
    }
}