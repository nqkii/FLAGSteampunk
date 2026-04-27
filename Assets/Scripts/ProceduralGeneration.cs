using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] private GameObject room1object;
    [SerializeField] private GameObject room2object;
    [SerializeField] private GameObject room3object;
    [SerializeField] private GameObject room4object;

    private roomType nextRoom;
    private GameObject deleteRoom;
    [SerializeField] private Vector3 nextRoomPosition;
    [SerializeField] private float scale;
    private roomType[] rooms;
    private Queue<GameObject> instantiatedRooms = new Queue<GameObject>();

    private void Start()
    {
        roomType room1 = new roomType(room1object, 4, 0);
        //roomType room2 = new roomType(room2object, 8, 0);
        //roomType room3 = new roomType(room3object, 8, -1.94f);
        //roomType room4 = new roomType(room4object, 8, 1.94f);
        nextRoom = room1;
        //rooms = new roomType[] { room1, room2, room3 };//, room4 };
        //Debug.Log(rooms);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NewRoom"))
        {
            GameObject newRoom = Instantiate(nextRoom.roomObject, nextRoomPosition, Quaternion.identity);
            newRoom.transform.localScale = new Vector3(scale, scale, scale);
            newRoom.transform.Rotate(0, -90, 0);
            instantiatedRooms.Enqueue(newRoom);
            nextRoomPosition.x += nextRoom.roomLength * scale;
            nextRoomPosition.y += nextRoom.verticalChange * scale;
            if (instantiatedRooms.Count > 8)
            {
                deleteRoom = instantiatedRooms.Dequeue();
                Destroy(deleteRoom);
            }
        }
        //int randomRoom = Random.Range(0, 3);
        //Debug.Log(randomRoom);
        //Debug.Log(rooms);
        //nextRoom = rooms[randomRoom];
    }

    private class roomType
    {
        public GameObject roomObject { get; }
        public float roomLength { get; }
        public float verticalChange { get; }

        public roomType(GameObject roomObject, float roomLength, float verticalChange)
        {
            this.roomObject = roomObject;
            this.roomLength = roomLength;
            this.verticalChange = verticalChange;
        }
    }
}
