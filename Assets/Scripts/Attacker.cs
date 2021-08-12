using UnityEngine;

public class Attacker : MonoBehaviour, IHealth
{
    [SerializeField] int startingHealth;

    #region Prefabs
    [Header("Prefabs")]
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] float deathVFXMaxLifetime;
    #endregion

    #region State
    [Header("State")]
    [SerializeField] float currentSpeed;
    [SerializeField] int currentHealth;
    #endregion

    void Start()
    {
        currentSpeed = 0;
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        // Debug.Log($"{name} took {damage} damage; now has {currentHealth} health");
        if (currentHealth <= 0)
        {
            Die();
		}
	}

    void Die()
    {
        // Debug.Log($"{name} is dead");
        TriggerDeathVFX();
        Destroy(gameObject);
	}

    void TriggerDeathVFX()
    { 
        if (!deathVFX) { return; }
        var deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, deathVFXMaxLifetime);
	}
}
