using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackers;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            float wait = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(wait);
            Spawn(RandomAttacker());
        }
    }

    private Attacker RandomAttacker()
    {
        int index = Random.Range(0, attackers.Length);
        return attackers[index];
    }

    private void Spawn(Attacker attacker)
    {
        Instantiate(attacker, transform);
    }
}
