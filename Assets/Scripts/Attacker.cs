using UnityEngine;

public class Attacker : MonoBehaviour, IHealth
{
    #region Stats
    [Header("Stats")]
    [SerializeField] int startingHealth;
    [SerializeField] int damagePerHit;
    [SerializeField] float movementSpeed;
    #endregion

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

    Animator animator;
    Defender currentTarget;
    Rigidbody2D rigidBody;

    void Awake()
    { 
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
	}

    void Start()
    {
        StopMoving();
        currentHealth = startingHealth;
    }

    void FixedUpdate()
    { 
        rigidBody.velocity = Vector2.left * currentSpeed;
	}

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }

	private void UpdateAnimationState()
    { 
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
		}
	}

    public void StopMoving()
    {
        currentSpeed = 0;
    }

    public void StartMoving()
    {
        currentSpeed = movementSpeed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender defender = collision.GetComponent<Defender>();
        if (defender != null) { OnMeetDefender(defender); }
    }

    protected virtual void OnMeetDefender(Defender defender)
    {
		currentTarget = defender;
		animator.SetBool("IsAttacking", true);
	}

    public void StrikeCurrentTarget()
    { 
        if (!currentTarget)
        { 
            animator.SetBool("IsAttacking", false);
            return;
		}
        currentTarget.DealDamage(damagePerHit);
	}
}
