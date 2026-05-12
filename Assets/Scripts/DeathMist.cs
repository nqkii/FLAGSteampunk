using UnityEngine;

public class DeathMist : MonoBehaviour
{
    public GameObject player;

    [Header("Speed Settings")]
    public float speedClose = 3f;
    public float speedNear = 4f;
    public float speedFar = 7f;
    public float speedVeryFar = 10f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        float speed;

        if (distance < 5)
            speed = speedClose;
        else if (distance < 10)
            speed = speedNear;
        else if (distance < 20)
            speed = speedFar;
        else
            speed = speedVeryFar;

        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}