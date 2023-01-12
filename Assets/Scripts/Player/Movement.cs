// using Settings;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float WalkSpeed = 1.96f;
    public float RunSpeed = 4f;
    public float JumpForce = 400;

    [Range(0, .3f)]
    public float movementSmooth = .05f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundTransform;
    [SerializeField] private Transform ceilingTransform;

    public UnityEvent OnLand;

    private bool grounded;
    private float groundCheckRadius = .2f;
    private Vector3 velocity = Vector3.zero;
    bool isRunning;

    Vector2 KeyboardInput;
    Vector2 LastInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundTransform.position, groundCheckRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;

                // for a particle effect, sfx etc
                if (!wasGrounded)
                    OnLand.Invoke();
            }
        }
    }

    void Move()
    {
        KeyboardInput.x = Input.GetAxisRaw("Horizontal");

        Vector3 targetVelocity = new Vector2(KeyboardInput.x * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmooth);

        if (grounded && Input.GetKey(KeyCode.Space))
        {
            grounded = false;
            rb.AddForce(new Vector2(0f, JumpForce));
        }

        if (KeyboardInput.sqrMagnitude > 0)
        {
            LastInput = KeyboardInput;
            transform.localScale = new Vector3(LastInput.x, 1, 0);
        }
    }
}