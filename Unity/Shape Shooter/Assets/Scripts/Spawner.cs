using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] projectilesPrefabs;
    public Transform positionToSpawn;
    public float timeBetweenProjectiles;
    
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnProjectiles());
	}

    private IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            GameObject projectileToSpawn = projectilesPrefabs[Random.Range(0, projectilesPrefabs.Length)];

            Instantiate(projectileToSpawn, positionToSpawn.position, Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenProjectiles);
        }
    }
}
