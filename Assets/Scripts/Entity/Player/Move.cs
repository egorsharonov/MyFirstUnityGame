using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float maxAirAcceleration = 20f;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;
    [SerializeField] private SceneController sceneController;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;

    private Animator animator;
    private float initialScaleX, initialScaleY;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        initialScaleX = transform.localScale.x; 
        initialScaleY = transform.localScale.y;
    }


    // Update is called once per frame
    void Update()
    {
        direction.x = input.RetrieveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);

        if (desiredVelocity.x > 0)
        {
            transform.localScale = new Vector3(initialScaleX, initialScaleY, 1);
        }
        else if (desiredVelocity.x < 0)
        {
            transform.localScale = new Vector3(-initialScaleX, initialScaleY, 1);
        }

        animator.SetFloat("speed", Mathf.Abs(desiredVelocity.x));
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        body.velocity = velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bound"))
        {
            sceneController.ReloadScene();
        }
    }
    public void ChangeMaxSpeed(float delta)
    {
        maxSpeed += delta;
    }
}