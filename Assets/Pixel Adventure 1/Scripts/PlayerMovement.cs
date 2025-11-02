using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpforce = 18f;
    [SerializeField] float runSpeed = 500f;
    [SerializeField] Text scoreText;

    private int count = 0;
    private float dirX = 0f;
    private bool jumpPressed = false;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField] LayerMask groundmask;

    private enum MovementState { idle, run, jump, fall }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jumpPressed && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
            jumpPressed = false;
        }

        HandleAnimation();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX * runSpeed * Time.fixedDeltaTime, rb.linearVelocity.y);
    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(GetComponent<Collider2D>().bounds.center,
                                 GetComponent<Collider2D>().bounds.size,
                                 0f, Vector2.down,
                                 0.1f, groundmask);
    }

    void HandleAnimation()
    {
        MovementState state;

        if (dirX > 0)
        {
            spriteRenderer.flipX = false;
            state = MovementState.run;
        }
        else if (dirX < 0)
        {
            spriteRenderer.flipX = true;
            state = MovementState.run;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.linearVelocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rb.linearVelocity.y < -0.1f)
        {
            state = MovementState.fall;
        }

        animator.SetInteger("state", (int)state);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fruit"))
        {
            Destroy(other.gameObject);
            count++;
            scoreText.text = "Count: " + count;
        }
    }

    // 📱 Mobile Touch Methods

    public void MoveLeftPress() { dirX = -1f; }
    public void MoveRightPress() { dirX = 1f; }
    public void StopMoving() { dirX = 0f; }
    public void JumpPress() { jumpPressed = true; }
}
