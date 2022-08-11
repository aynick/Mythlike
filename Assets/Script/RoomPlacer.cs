using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class RoomPlacer : MonoBehaviour
    {
        [Header("Prefabs")] 
        [SerializeField] private Room roomTemplate;

        [SerializeField] private Room startRoom;
        
        private Room[,] _spawnedRooms;
        private Room[,] instantiatedRooms;
        private int _roomsCurrentCount;
        
        [Header("Map Setting")]
        [SerializeField] private Vector2Int mapSize;

        [SerializeField] private Vector2Int startRoomPosition;
        [Header("Rooms Count")]
        [SerializeField] private int maxRooms;

        private Room currentRoom;
        private Vector2Int currentRoomPos;
        private bool IsHaveRooms;

        private Vector2Int[] mayDir = new Vector2Int[]
        {
            Vector2Int.down, Vector2Int.left, Vector2Int.up, Vector2Int.right
        };
        private Vector2Int[] checkDir = new Vector2Int[]
        {
            Vector2Int.down, Vector2Int.left, Vector2Int.up,Vector2Int.right,Vector2Int.down + Vector2Int.right,Vector2Int.down + Vector2Int.left,Vector2Int.up + Vector2Int.right, Vector2Int.up + Vector2Int.left, 
        };

        [SerializeField]private int maxRewardRooms;
        private int currentRewardRooms;
        [SerializeField]private int maxShopRooms;
        private int currrentShopRooms;

        private Room lastRoom;

        [SerializeField] private List<Room> Rooms = new List<Room>();

        private void OnValidate()
        {
            if (maxRooms > mapSize.x * mapSize.y)
            {
                maxRooms = mapSize.x * mapSize.y;
            }
            else if (maxRooms < 0)
            {
                maxRooms = 0;
            }

            if (startRoomPosition == new Vector2Int())
            {
                startRoomPosition = new Vector2Int(mapSize.x / 2, mapSize.y / 2);
            }
            else if (startRoomPosition.x < 0 || startRoomPosition.y < 0 || startRoomPosition.x > mapSize.x || startRoomPosition.y > mapSize.y)
            {
                startRoomPosition = new Vector2Int(mapSize.x / 2, mapSize.y / 2);
            }
        }

        private IEnumerator Start()
        {
            _spawnedRooms = new Room[mapSize.x, mapSize.y];
            instantiatedRooms = new Room[mapSize.x, mapSize.y];
            int limit = 2000;
            while (_roomsCurrentCount < maxRooms && limit-- > 0)
            {
                yield return new WaitForSeconds(0.1f);
                Generate();
            }

            lastRoom.RoomType = RoomType.Boss;
        }

        void Generate()
        {
            if (!IsHaveRooms)
            {
                var startRoom = _spawnedRooms[startRoomPosition.x, startRoomPosition.y] = this.startRoom;
                instantiatedRooms[startRoomPosition.x, startRoomPosition.y] = startRoom;
                currentRoom = startRoom;
                currentRoomPos = startRoomPosition;
                IsHaveRooms = true;
            }
            else
            {
                var newRoom = roomTemplate;
                currentRoom = newRoom;
                newRoom.ConnectionCount = Random.Range(1, 3);
                newRoom.currentConnectionCount = 1;
                var targetPos = currentRoomPos + mayDir[Random.Range(0, mayDir.Length)];
                TryAddToArray(targetPos,newRoom);
            }
        }

        void TryAddToArray(Vector2Int pos,Room room)
        {
            int maxX = _spawnedRooms.GetLength(0)-1;
            int maxY = _spawnedRooms.GetLength(1)-1;
            if (room.ConnectionCount <= room.currentConnectionCount)
            {
                return;
            }
            if (pos.x < 1 || pos.y<1 || pos.x >= maxX || pos.y >= maxY)
            {
                return;
            }

            if (_spawnedRooms[pos.x, pos.y] == null)
            {
                var vacantplace = 0;
                for (int i = 0; i < checkDir.Length; i++)
                {
                    var position = currentRoomPos + checkDir[i];
                    
                    if (_spawnedRooms[position.x,position.y] == null)
                    {
                        vacantplace++;
                    }
                }

                if (vacantplace < 5)
                {
                    var chance = Random.Range(0, 100);
                    if (chance < 10) return;
                }
                _spawnedRooms[pos.x, pos.y] = room;
                _roomsCurrentCount++;
                currentRoomPos = new Vector2Int(pos.x, pos.y);
                currentRoom.currentConnectionCount++;
                InstantiateRoom(currentRoomPos, room);
                Rooms.Add(room);
            }
        }

        void InstantiateRoom(Vector2Int pos, Room room)
        {
            var newRoom = Instantiate(room, transform);
            instantiatedRooms[pos.x, pos.y] = newRoom;
            newRoom.ConnectionCount = room.ConnectionCount;
            newRoom.transform.localPosition =
                new Vector2((pos.x - startRoomPosition.x) * 41, (pos.y - startRoomPosition.y) * 29);
            AddTypeToRoom(newRoom);
            ConnectRoom(pos,newRoom);
            lastRoom = newRoom;
        }

        void AddTypeToRoom(Room room)
        {
            if (_roomsCurrentCount > maxRooms / 2 && maxRewardRooms > currentRewardRooms)
            {
                room.RoomType = RoomType.Reward;
                currentRewardRooms++;
                return;
            }

            int chance = Random.Range(0, 100);
            if (chance < 10 && currrentShopRooms < maxShopRooms)
            {
                room.RoomType = RoomType.Shop;
                currrentShopRooms++;
                return;
            }
            room.RoomType = RoomType.Regular;
        }

        void ConnectRoom(Vector2Int p, Room room)
        {
            for (int i = 0; i < mayDir.Length; i++)
            {
                
                var pos =p + mayDir[i];
                var selectRoom = instantiatedRooms[pos.x, pos.y];
                if (selectRoom != null)
                {
                    if (mayDir[i] == Vector2Int.down)
                    {
                        room.DoorD.Lock(false);
                        selectRoom.DoorU.Lock(false);
                    }
                    
                    if (mayDir[i] == Vector2Int.left)
                    {
                        room.DoorL.Lock(false);
                        selectRoom.DoorR.Lock(false);
                    }
                    
                    if (mayDir[i] == Vector2Int.right)
                    {
                        
                        room.DoorR.Lock(false);
                        selectRoom.DoorL.Lock(false);
                    }
                    
                    if (mayDir[i] == Vector2Int.up)
                    {
                        room.DoorU.Lock(false);
                        selectRoom.DoorD.Lock(false);
                    }
                }
            }
        }
    }
}