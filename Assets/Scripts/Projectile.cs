using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth health = collision.GetComponent<IHealth>();
        if (health != null)
        {
            collision.GetComponent<IHealth>()?.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
