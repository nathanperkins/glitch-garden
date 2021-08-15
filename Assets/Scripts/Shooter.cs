using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject projectilePrefab;

    [Header("Projectile")]
    [SerializeField] GameObject gun;
    [Range(0.5f, 5)]
    [SerializeField] float projectileVelocity; 
    [Range(0, 720)]
    [SerializeField] float projectileRotation;

    Spawner spawner;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("shoot pew pew");
            // TODO: Change animation state to Shooting.
		}
        else
        {
            Debug.Log("sit and wait");
            // TODO: Change animation state to Idle.
		}
    }

    private void SetLaneSpawner()
    {
        float myYPos = transform.position.y;
        foreach (var spawner in FindObjectsOfType<Spawner>())
        {
            float spawnerYPos = spawner.transform.position.y;
            if (Mathf.Approximately(myYPos, spawnerYPos))
            {
                this.spawner = spawner;
                return;
			}
		}
        throw new System.Exception($"No spawner found in {name}'s lane");
	}

    private bool IsAttackerInLane()
    { 
        if (spawner == null)
        {
            return false;
		}

        return spawner.GetComponentInChildren<Attacker>() != null;
	}

    public void Fire()
	{
        // Debug.Log("Fire!");
        var projectile = Instantiate(
            projectilePrefab,
            gun.transform.position,
            Quaternion.identity
		);

        var body = projectile.GetComponent<Rigidbody2D>();
        body.velocity = Vector2.right * projectileVelocity;
        body.angularVelocity = -projectileRotation;
	}
}
