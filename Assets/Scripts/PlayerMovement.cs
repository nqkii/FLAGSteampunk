using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    Rigidbody rb;
    Animator animator;
    bool facingRight;

    private float originalSpeed;
    private float originalJumpForce;

    [Header("Jumping")]
    public float jumpForce = 10;
    public bool onGround;
    public float fallMultiplier = 2.5f;

    [Header("Dashing")]
    public bool canDash = true;
    public float dashingTime;
    public float dashSpeed;
    public float dashJumpIncrease;
    public float timeBetweenDashes;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        facingRight = true;

        originalSpeed = speed;
        originalJumpForce = jumpForce;

        if (rb == null)
            Debug.LogError("Rigidbody not found!");
        else
            Debug.Log("Rigidbody found on: " + rb.gameObject.name);

        if (animator == null)
            Debug.LogError("Animator not found!");
        else
            Debug.Log("Animator found on: " + animator.gameObject.name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0);
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (!onGround && Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }

        animator.SetFloat("Jump", rb.linearVelocity.y);
        animator.SetBool("IsGrounded", onGround);
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector3(move * speed, rb.linearVelocity.y, 0);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180.0f, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            onGround = false;
        }
    }

    void DashAbility()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        speed = dashSpeed;
        jumpForce = dashJumpIncrease;
        animator.SetTrigger("Dash");

        yield return new WaitForSeconds(dashingTime);

        speed = originalSpeed;
        jumpForce = originalJumpForce;

        yield return new WaitForSeconds(timeBetweenDashes);
        canDash = true;
    }
}