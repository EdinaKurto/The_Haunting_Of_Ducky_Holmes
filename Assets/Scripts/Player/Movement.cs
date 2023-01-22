using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float WalkSpeed = 2.7f;
    public float JumpForce = 500f;
    public int GroundedDrag, AirDrag;

    [SerializeField] private LayerMask hidableLayer;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundTransform;

    public UnityEvent OnLand;

    private Animator animator;
    private bool grounded;
    private bool hasJumped;
    private float groundCheckRadius = .2f;

    Vector2 keyboardInput;
    Vector2 LastInput;
    PlayerManager manager;

    private void Awake()
    {
        manager = PlayerManager.Instance;

        animator = manager.PlayerAnimator;
        rb = manager.RB;
    }

    private void Update()
    {
        keyboardInput.x = Input.GetAxisRaw("Horizontal");

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;
            hasJumped = true;
        }
    }

    private void FixedUpdate()
    {
        if (manager.Hidden)
            return;

        Move();

        bool wasGrounded = grounded;
        grounded = false;

        // Check for nearby colliders
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundTransform.position, groundCheckRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;

                // Play a particle effect, sfx etc
                if (!wasGrounded)
                    OnLand.Invoke();
            }
        }
    }

    void Move()
    {
        rb.drag = grounded ? GroundedDrag : AirDrag;

        if (hasJumped)
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            hasJumped = false;
        }

        rb.AddForce((keyboardInput.x * WalkSpeed) * Vector2.right);

        if (keyboardInput.sqrMagnitude > 0)
        {
            LastInput = keyboardInput;
            transform.localScale = new Vector3(LastInput.x, 1, 0);
        }

        // Trigger Animation
        animator.SetBool("Grounded", grounded);
        animator.SetBool("Walking", keyboardInput.sqrMagnitude > 0);
    }
}