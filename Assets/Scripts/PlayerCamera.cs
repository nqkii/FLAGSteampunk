using UnityEngine;
public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0.5f, 1, -4.9f);
        transform.position = new Vector3(transform.position.x, 2.38f, transform.position.z);
    }
}