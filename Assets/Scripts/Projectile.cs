using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage;
    [Range(0.5f, 5)]
    [SerializeField] float velocity;
    [Range(0, 720)]
    [SerializeField] float rotation;

    private void Start()
    {
        var body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.right * velocity;
        body.angularVelocity = -rotation;
    }

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
