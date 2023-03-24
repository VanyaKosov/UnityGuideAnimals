using Assets.Scripts;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float SpawnInterval;

    public GameObject[] AnimalsPrefabs;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", SpawnInterval, SpawnInterval);
    }

    void SpawnRandomAnimal()
    {
        var side = Random.Range(0, 4);

        var field = Settings.Field;
        var world = Settings.World;

        var rotatation = 0f;
        var spawnPos = new Vector3();

        switch (side)
        {
            case 0: // top
            case 1: // bottom
                spawnPos.x = Random.Range(field.Left, field.Right);
                spawnPos.z = side == 0 ? world.Top : world.Bottom;
                rotatation = side == 0 ? 0 : 180;
                break;
            case 2: // right
            case 3: // left
                spawnPos.z = Random.Range(field.Top, field.Bottom);
                spawnPos.x = side == 2 ? world.Right : world.Left;
                rotatation = side == 2 ? 90 : 270;
                break;
        }

        //var spawnX = Random.Range(field.Left, field.Right);
        //var spawnPos = new Vector3(spawnX, 0, Settings.World.Top);

        var index = Random.Range(0, AnimalsPrefabs.Length);
        var animal = AnimalsPrefabs[index];

        var spawnedAnimal = Instantiate(animal, spawnPos, animal.transform.rotation);
        spawnedAnimal.transform.Rotate(Vector3.up, rotatation);
    }
}
