using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] private GameObject room1object;
    [SerializeField] private GameObject room2object;
    [SerializeField] private GameObject room3object;
    [SerializeField] private GameObject room4object;
    [SerializeField] private GameObject room5object;
    [SerializeField] private GameObject room6object;
    [SerializeField] private GameObject room7object;
    [SerializeField] private GameObject room8object;
    [SerializeField] private GameObject room9object;
    [SerializeField] private GameObject room10object;
    [SerializeField] private GameObject room11object;
    [SerializeField] private GameObject room12object;
    [SerializeField] private GameObject room13object;

    private roomType nextRoom;
    private GameObject deleteRoom;
    [SerializeField] private Vector3 nextRoomPosition;
    [SerializeField] private float scale;
    private roomType[] smallRooms;
    private roomType[] bigRooms;
    private bool nextRoomBig = false;
    private Queue<GameObject> instantiatedRooms = new Queue<GameObject>();
    private bool isColliding = false;
    private int maxRooms = 8;
    private bool pauseNewRoom = false;

    private void Start()
    {
        roomType room1 = new roomType(room1object, 4, 0);
        roomType room2 = new roomType(room2object, 4, 0);
        roomType room3 = new roomType(room3object, 4, 0);
        roomType room4 = new roomType(room4object, 8, 0);
        roomType room5 = new roomType(room5object, 8, 0);
        roomType room6 = new roomType(room6object, 8, 0);
        roomType room7 = new roomType(room7object, 8, 0);
        roomType room8 = new roomType(room8object, 4, 0);
        roomType room9 = new roomType(room9object, 4, 0);
        roomType room10 = new roomType(room10object, 8, 0);
        roomType room11 = new roomType(room11object, 8, 0);
        roomType room12 = new roomType(room12object, 8, 0);
        roomType room13 = new roomType(room13object, 8, 0);
        smallRooms = new roomType[] { room1, room2, room3, room4, room5, room6, room7};
        bigRooms = new roomType[] { room8, room9, room10, room11, room12, room13};
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NewRoom") && !pauseNewRoom)
        {
            if (isColliding) return;
            isColliding = true;
            Vector3 dir = other.transform.position - transform.position;
            if (dir.x > 0)
            {
                if (!nextRoomBig)
                {
                    int randomRoom = Random.Range(0, 7);
                    nextRoom = smallRooms[randomRoom];
                    if (randomRoom >= 5)
                    {
                        nextRoomBig = true;
                    }
                }
                else
                {
                    int randomRoom = Random.Range(0, 6);
                    nextRoom = bigRooms[randomRoom];
                    if (randomRoom >= 4)
                    {
                        nextRoomBig = false;
                    }
                }

                    GameObject newRoom = Instantiate(nextRoom.roomObject, nextRoomPosition, Quaternion.identity);
                newRoom.transform.localScale = new Vector3(scale, scale, scale);
                newRoom.transform.Rotate(0, -90, 0);

                instantiatedRooms.Enqueue(newRoom);
                nextRoomPosition.x += nextRoom.roomLength * scale;
                nextRoomPosition.y += nextRoom.verticalChange * scale;

                if (instantiatedRooms.Count > maxRooms)
                {
                    deleteRoom = instantiatedRooms.Dequeue();
                    Destroy(deleteRoom);
                }
            }
            else
            {
                maxRooms++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NewRoom"))
        {
            Vector3 dir = other.transform.position - transform.position;
            if (dir.x > 0)
            {
                pauseNewRoom = true;
            }
            else
            {
                pauseNewRoom = false;
            }
        }
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

    private void Update()
    {
        isColliding = false;
    }
}
