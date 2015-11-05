using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public int spawnRate;
    public float spawnTimer;
    public int spawnAmount;
    public float spawnDistance;

    public GameObject dwarfEnemy;

    private GameObject player;

    private bool canSpawn;
    private bool isSpawning;

	void Start () 
    {
        canSpawn = true;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void Update () 
    {
        if (canSpawn)
        {
            if(Vector3.Distance(transform.position,player.transform.position) < spawnDistance)
            {
                isSpawning = true;
            }
        }

        if (isSpawning)
        {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer <= 0)
        {
            if (spawnAmount > 0)
            {
                spawnAmount -= 1;
                spawnTimer = spawnRate;
                SpawnEnemy();
            }
            else
            {
                canSpawn = false;
                isSpawning = false;
            }
        }
        
	}

    private void SpawnEnemy()
    {
        Instantiate(dwarfEnemy, transform.position, transform.rotation);
    }
}
