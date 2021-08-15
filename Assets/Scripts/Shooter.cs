using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject projectilePrefab;

    [Header("Projectile")]
    [SerializeField] GameObject gun;

    Animator animator;
    Spawner spawner;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        animator.SetBool("IsAttacking", IsAttackerInLane());
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
        Instantiate(
             projectilePrefab,
             gun.transform.position,
             Quaternion.identity);
    }
}
