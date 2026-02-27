using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Transform player;

    Rigidbody rb;

    bool facingRight;

    public float jumpForce = 10;
    bool onGround;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        facingRight = true;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        //character moves horizontally
        rb.linearVelocity = new Vector3(move * speed, rb.linearVelocity.y, 0);
        
        //player flips towards the moving direction
        if(move>0 && !facingRight)
        {
            Flip();
        }
        else if(move<0 && facingRight)
        {
            Flip();
        }

        //jump when on ground and pressing space
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        player.transform.Rotate(0, 180.0f, 0);
    }

    //ground check
    private void OnTriggerStay(Collider other)
    {
        onGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        onGround = false;
    }

}
