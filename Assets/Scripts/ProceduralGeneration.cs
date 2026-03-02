using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] private GameObject room1object;
    [SerializeField] private GameObject room2object;
    [SerializeField] private GameObject room3object;
    [SerializeField] private GameObject room4object;

    private roomType nextRoom;
    private Vector3 nextRoomPosition;

    private void Start()
    {
        roomType room1 = new roomType(room1object, 4, 0);
        roomType room2 = new roomType(room2object, 8, 0);
        roomType room3 = new roomType(room3object, 8, -1.94f);
        roomType room4 = new roomType(room4object, 8, 1.94f);
        nextRoom = room3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NewRoom"))
        {
            Instantiate(nextRoom.roomObject, nextRoomPosition, Quaternion.identity);
            nextRoomPosition.z += nextRoom.roomLength;
            nextRoomPosition.y += nextRoom.verticalChange;
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
}
