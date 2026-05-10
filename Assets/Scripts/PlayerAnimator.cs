using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Running - checks if the player is moving horizontally
        float speed = Mathf.Abs(rb.linearVelocity.x);
        animator.SetBool("isRunning", speed > 0.1f);

        // Jumping - checks vertical velocity
        bool isJumping = (rb.linearVelocity.y) > 0.1f;
        animator.SetBool("isJumping", isJumping);
    }
}