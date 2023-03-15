using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float SpawnXRange;

    public float SpawnZ;

    public float SpawnInterval;

    public GameObject[] AnimalsPrefabs;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", SpawnInterval, SpawnInterval);
    }

    void SpawnRandomAnimal()
    {
        var spawnX = Random.Range(-SpawnXRange, SpawnXRange);
        var spawnPos = new Vector3(spawnX, 0, SpawnZ);

        var index = Random.Range(0, AnimalsPrefabs.Length);
        var animal = AnimalsPrefabs[index];

        Instantiate(animal, spawnPos, animal.transform.rotation);
    }
}
