using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    public UnityEvent OnCollide;

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollide.Invoke();
        Destroy(this.gameObject);
    }

}