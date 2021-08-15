using UnityEngine;

public class Lizard : Attacker
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender defender = collision.GetComponent<Defender>();
        if (defender != null) { Attack(defender); }
    }
}
