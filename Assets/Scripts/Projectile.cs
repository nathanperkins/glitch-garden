using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IHealth>()?.DealDamage(damage);
		Destroy(gameObject);
    }
}
