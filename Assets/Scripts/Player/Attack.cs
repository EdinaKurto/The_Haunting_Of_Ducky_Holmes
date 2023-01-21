using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Pivot;
    public float Power = 10;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var temp = Instantiate(Prefab, Pivot.position, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().AddForce(transform.localScale.x * Vector2.right * Power);
            Destroy(temp, 6);
        }
    }
}
