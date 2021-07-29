using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Attacker attackerPrefab;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn() {
        while(true) { 
			float wait = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(wait);

            Instantiate(attackerPrefab, transform);
		}
	}
}
