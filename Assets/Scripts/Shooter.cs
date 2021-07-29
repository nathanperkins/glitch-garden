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

    public void Fire()
	{
        Debug.Log("Fire!");
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
