using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] projectilesPrefabs;
    public Transform positionToSpawn;
    public float timeBetweenProjectiles;

    private bool spawnObjects = true;
    
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnProjectiles());
	}

    private IEnumerator SpawnProjectiles()
    {
        while (spawnObjects)
        {
            GameObject projectileToSpawn = projectilesPrefabs[Random.Range(0, projectilesPrefabs.Length)];

            Instantiate(projectileToSpawn, positionToSpawn.position, Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenProjectiles);
        }
    }
}
