using UnityEngine;

public class DeathMist : MonoBehaviour
{
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 5)
        {
            transform.position += transform.right * 3f * Time.deltaTime;
        }
        if ( distance < 10 )
        {
            transform.position += transform.right * 4f * Time.deltaTime;
        }

        if (distance > 10 )
        {
            transform.position += transform.right * 7f * Time.deltaTime;
        }
        if (distance > 20)
        {
            transform.position += transform.right * 10f * Time.deltaTime;

        }

    }
}
