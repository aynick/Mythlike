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
        [SerializeField] private Room[] rooms;
        [SerializeField] private Room startRoom;
        private Room[,] _spawnedRooms;
        private int _roomsCurrentCount;
        [Header("Map Setting")]
        [SerializeField] private Vector2Int mapSize;
        [SerializeField]private Vector2Int startRoomPosition = new Vector2Int();
        [Header("Rooms Count")]
        [SerializeField] private int maxRooms;
        [SerializeField] private int rewardRoomMaxCount;
        private int _rewardRoomCurrentCount;
        [SerializeField] private int bossRoomMaxCount;
        private int _bossRoomCurrentCount;
        [SerializeField] private int shopRoomMaxCount;
        private int _shopRoomCurrentCount;

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
            _spawnedRooms = new Room[mapSize.x,mapSize.y];
            _spawnedRooms[startRoomPosition.x,startRoomPosition.y] = startRoom;
            int limit = 500;
            while (limit-- > 0)
            {
                yield return new WaitForSeconds(1);
                Generate();
            }
        }

        private void Generate()
        {
            HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
                for (int x = 0 + 1; x < _spawnedRooms.GetLength(0) - 1; x++)
                {
                    for (int y = 0 + 1; y < _spawnedRooms.GetLength(1) - 1; y++)
                    {
                        if (_spawnedRooms[x, y] == null) continue;
                        if (x > 0 && _spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                        if (x > 0 && _spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                        if (x > 0 && _spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                        if (x > 0 && _spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
                    }
                }
                Room newRoom = Instantiate(rooms[Random.Range(0, rooms.Length)], transform);
                if (!CheckRoomType(newRoom)) return;
                int limit = 100;
                while (limit-- > 0)
                {
                    Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
                    if (ConnectToSomething(newRoom,position))
                    {
                        newRoom.transform.localPosition = new Vector3((position.x - startRoomPosition.x)*27, (position.y - startRoomPosition.y) * 15, transform.position.z);
                        _spawnedRooms[position.x, position.y] = newRoom;
                        Debug.Log(newRoom.transform.position + "-transform " + position +"- position" );
                        return;
                    }
                }
                Destroy(newRoom.gameObject);
        }

        private bool CheckRoomType(Room room)
        {
            switch (room.RoomType)
            {
                //Room Checker
                case RoomType.Reward when _rewardRoomCurrentCount >= rewardRoomMaxCount:
                    Destroy(room.gameObject);
                    return false;
                case RoomType.Reward when _rewardRoomCurrentCount < rewardRoomMaxCount:
                    _rewardRoomCurrentCount++;
                    return true;
                case RoomType.Boss when _bossRoomCurrentCount >= bossRoomMaxCount:
                    Destroy(room.gameObject);
                    return false;
                case RoomType.Boss when _bossRoomCurrentCount < bossRoomMaxCount:
                    _bossRoomCurrentCount++;
                    return true;
                case RoomType.Start:
                    Destroy(room.gameObject);
                    return false;
                case RoomType.Shop when _shopRoomCurrentCount >= shopRoomMaxCount:
                    Destroy(room.gameObject);
                    return false;
                case RoomType.Shop when _shopRoomCurrentCount < shopRoomMaxCount:
                    _shopRoomCurrentCount++;
                    return true;
                case RoomType.Regular:
                    return true;
                default:
                    return true;
            }
        }

        private bool ConnectToSomething(Room room, Vector2Int pos)
        {
            int maxX = _spawnedRooms.GetLength(0) - 1;
            int maxY = _spawnedRooms.GetLength(1) - 1;
            List<Vector2Int> neighbours = new List<Vector2Int>();
            if (room.DoorD != null && pos.y > 1 && _spawnedRooms[pos.x, pos.y - 1]?.DoorU != null)
                neighbours.Add(Vector2Int.down);
            if (room.DoorU != null && pos.y < maxY && _spawnedRooms[pos.x, pos.y + 1]?.DoorD != null)
                neighbours.Add(Vector2Int.up);
            if (room.DoorR != null && pos.x < maxX && _spawnedRooms[pos.x + 1, pos.y]?.DoorL != null)
                neighbours.Add(Vector2Int.right);
            if (room.DoorL != null && pos.x > 1 && _spawnedRooms[pos.x - 1, pos.y]?.DoorR != null)
                neighbours.Add(Vector2Int.left);
            if (neighbours.Count == 0) return false;
            Vector2Int dir = neighbours[Random.Range(0, neighbours.Count)];
            Room selectedRoom = _spawnedRooms[pos.x + dir.x, pos.y + dir.y];
            _roomsCurrentCount++;
            //RoomConnector
            if (dir == Vector2Int.down)
            {
                room.DoorD.SetActive(false);
                selectedRoom.DoorU.SetActive(false);
            }
            else if (dir == Vector2Int.up)
            {
                room.DoorU.SetActive(false);
                selectedRoom.DoorD.SetActive(false);
            }
            else if (dir == Vector2Int.right)
            {
                room.DoorR.SetActive(false);
                selectedRoom.DoorL.SetActive(false);
            }
            else if (dir == Vector2Int.left)
            {
                room.DoorL.SetActive(false);
                selectedRoom.DoorR.SetActive(false);
            }

            return true;
    }
    }
}