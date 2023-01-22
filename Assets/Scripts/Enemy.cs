using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float dirX;
    private float moveSpeed = 7f;
    private Rigidbody2D rb;

    public LayerMask PlayerMask;

    [SerializeField] private GameObject gotchaText;

    private void Awake()
    {
        //   gotchaText?.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    private void Update()
    {
        if (transform.position.x < -9f)
            dirX = 1f;
        else if (transform.position.x < 9f)
            dirX = -1f;

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (((1 << other.gameObject.layer) & PlayerMask) != 0)
        {
            Debug.Log("Caught the Duck");
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
