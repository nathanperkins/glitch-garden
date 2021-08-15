using UnityEngine;

public class Defender : MonoBehaviour, IHealth
{
    [SerializeField] int cost = 100;
    [SerializeField] int health = 1;

    public int GetStarCost() { return cost; }

    public void DealDamage(int damage) {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered at {name}");
    }
}
