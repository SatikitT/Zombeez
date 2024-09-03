using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectsToSpawn; // List of prefabs to spawn
    public float spawnRate = 2f;            // Time between spawns
    public float spawnYMin = -4f;           // Minimum Y position for spawning
    public float spawnYMax = 1f;            // Maximum Y position for spawning
    public float moveSpeed = 5f;            // Speed of the object's movement
    public float destroyX = -10f;           // X position at which to destroy the object

    private float nextSpawnTime;

    void Update()
    {
        HandleSpawning();
    }

    void HandleSpawning()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnObject()
    {
        if (objectsToSpawn.Count == 0) return;

        // Randomly select an object from the list
        int randomIndex = Random.Range(0, objectsToSpawn.Count);
        GameObject objectToSpawn = objectsToSpawn[randomIndex];

        float spawnY = Random.Range(spawnYMin, spawnYMax);
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, 0);
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        spawnedObject.AddComponent<MoveAndDestroy>();
        spawnedObject.GetComponent<MoveAndDestroy>().moveSpeed = moveSpeed;
        spawnedObject.GetComponent<MoveAndDestroy>().destroyX = destroyX;
    }
}

public class MoveAndDestroy : MonoBehaviour
{
    public float moveSpeed;
    public float destroyX;

    void Update()
    {
        MoveObject();
        CheckForDestruction();
    }

    void MoveObject()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    void CheckForDestruction()
    {
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
