using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Attacker attackerPrefab;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;


    // Start is called before the first frame update
    IEnumerator Start() {
        while(true) { 
			float wait = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(wait);
            SpawnAttacker();
		}
	}

    private void SpawnAttacker()
    { 
            Attacker attacker = Instantiate(attackerPrefab, transform);
	}
}
