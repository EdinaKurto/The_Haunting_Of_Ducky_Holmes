using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer Sprite;

    public Vector2 Bound = new Vector2(1, 1);
    public LayerMask PlayerMask;
    public float Speed = 7f;
    public bool DirectionRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x <= Bound.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            DirectionRight = false;
        }

        if (transform.position.x >= Bound.y)
        {
            transform.localScale = new Vector3(1, 1, 1);
            DirectionRight = true;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2((DirectionRight ? -1 : 1) * Speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (((1 << other.gameObject.layer) & PlayerMask) != 0)
        {
            Debug.Log("Caught the Duck");
            GameHandler.Instance.OnCaught();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (((1 << other.gameObject.layer) & PlayerMask) != 0)
        {
            Debug.Log("Lost the Duck");
        }
    }
}
