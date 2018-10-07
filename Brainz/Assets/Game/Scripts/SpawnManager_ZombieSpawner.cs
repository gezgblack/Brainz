using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnManager_ZombieSpawner : MonoBehaviour
{


    [SerializeField]
    GameObject zombiePrefab;

    private GameObject go;

    private GameObject[] zombieSpawns;

    int counter = 0;
    int zombieHealthIncreaser = 120; //increasing zombie health
    int zombieDamageIncreaser = 5; //increasing zombie damage
    private int numberOfZombies = 5; //number of zombies

    public waveIncreaser waveCount;

    private int maxNumberOfZombies = 40; //maximum number of zombies
    private float waveRate = 10; //time between the zombie spawns(waves of zombies)
    private bool isSpawnActivated = true; //for triggering(spawning of zombies)

    //dayNightCycle dayNight;
    public float amount = 0;
    public float fadeTime = 1f;

    public void Start()
    {
        zombieSpawns = GameObject.FindGameObjectsWithTag("ZombieSpawn");

        waveCount = GameObject.Find("zombieWave").GetComponent<waveIncreaser>();

        StartCoroutine(ZombieSpawner());
    }

    IEnumerator ZombieSpawner() //to spawn our zombies
    {
        for (;;)
        {
            yield return new WaitForSeconds(waveRate); //wait selected amount before spawning more zombies
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie"); //find all the zombies

            if (zombies.Length == 0)
            {
                waveCount.increasewave();
                CommenceSpawn();
                numberOfZombies += 5; //increase the amount of zombies to spawn by 1
                zombieHealthIncreaser += 5; //increase the zombie health by 2 with each new zombie added
                zombieDamageIncreaser++; //increase the zombie damage by 1 with each new zombie added
            }
        }
    }

    void CommenceSpawn()
    {
        if (isSpawnActivated) //if spawning zombs activated
        {
            for (int i = 0; i < numberOfZombies; i++)
            {
                int randomIndex = Random.Range(0, zombieSpawns.Length); //randomly select a zombie spawn point
                SpawnZombies(zombieSpawns[randomIndex].transform.position); //spawn the zombies
            }
        }
    }

    void SpawnZombies(Vector3 spawnPos)
    {
        counter++; //everytime a new zombie is spawned incremenet counter {for zombie ID purpose}
        go = GameObject.Instantiate(zombiePrefab, spawnPos, Quaternion.identity) as GameObject; //at the set position of the spawn object
        //go.GetComponent<Zombie_ID>().zombieID = "Zombie " + counter; //new zombie naming scheme Zombie 1, 2, 3, etc..
        //go.GetComponent<enemyHealth>().currentHealth = 100f; //setting the new increased zombie health
        //go.GetComponent<enemyDamage>().damage = 6f; //setting the new increased zombie damage
        //NetworkServer.Spawn(go);
    }
}