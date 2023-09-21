using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 10f)] private float jumpHeight = 5f;
    [SerializeField, Range(0, 3)] private int maxAirJumps = 1;
    [SerializeField, Range(0, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0, 5f)] private float upwardMovementMultiplier = 1.5f;

    private Rigidbody2D body;
    private Ground ground;
    private Vector2 velocity;

    private int jumpPhase;
    private float defaultGravityScale;

    private bool desiredJump;
    private bool onGround;

    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        animator = GetComponent<Animator>();

        defaultGravityScale = 1f;

    }

    // Update is called once per frame
    private void Update()
    {
        desiredJump |= input.RetrieveJumpInput();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        if (onGround)
            jumpPhase = 0;

        if (desiredJump)
        {
            JumpAction();
            desiredJump = false;   
        }

        if (body.velocity.y > 0)
            body.gravityScale = upwardMovementMultiplier;
        else if (body.velocity.y < 0)
            body.gravityScale = downwardMovementMultiplier;
        else
            body.gravityScale = defaultGravityScale;

        body.velocity = velocity;
    }


    private void JumpAction()
    {
        if (onGround || (jumpPhase <= maxAirJumps))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
            ++jumpPhase;
            animator.SetBool("isJumping", true);
            if (jumpPhase >= 2)
                animator.SetTrigger("DoubleJump");
            
            float jumpSpeed = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);

            if (velocity.y > 0f)
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);

            velocity.y += jumpSpeed;
        }
    }
    public void ChangeMaxAirJumps(int delta)
    {
        maxAirJumps = Mathf.Min(maxAirJumps+delta, 5);
    }
}