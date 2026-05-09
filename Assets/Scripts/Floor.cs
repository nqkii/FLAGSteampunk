using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] Rigidbody player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, -0.38f, 0.22f);
    }
}
