using UnityEngine;

public class Defender : MonoBehaviour, IHealth
{
    [SerializeField] int cost = 100;
    [SerializeField] protected int health = 1;

    public int GetStarCost() { return cost; }

    public virtual void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
