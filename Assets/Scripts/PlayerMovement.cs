using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public Transform player;

    Rigidbody rb;

    bool facingRight;

    [Header("Jumping")]
    public float jumpForce = 10;
    public bool onGround;

    [Header("Dashing")]
    public bool canDash = true;
    public float dashingTime;
    public float dashSpeed;
    public float dashJumpIncrease;
    public float timeBetweenDashes;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        facingRight = true;
    }

    void Update()
    {
        //jump when on ground and pressing space
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        // dash when off ground and pressing left shift
        if (!onGround && Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
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

    }

    //flip player
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

    void DashAbility()
    {
        if(canDash)
        {
            StartCoroutine(Dash());
        }
    }

    //dash player
    IEnumerator Dash()
    {
        canDash = false;
        speed = dashSpeed;
        jumpForce = dashJumpIncrease;
        yield return new WaitForSeconds(dashingTime);
        speed = 9;
        jumpForce = 5;
        yield return new WaitForSeconds(timeBetweenDashes);
        canDash = true;
    }
}
