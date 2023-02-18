using UnityEngine;

public class Attack : MonoBehaviour
{
    PlayerManager manager;

    public GameObject Prefab;
    public Transform Pivot;
    public float Power = 10;

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !manager.Hidden)
        {
            var temp = Instantiate(Prefab, Pivot.position, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().AddForce(transform.localScale.x * Vector2.right * Power);
            temp.transform.localScale = new Vector2(transform.localScale.x, 1);
            Destroy(temp, 6);
        }
    }
}
