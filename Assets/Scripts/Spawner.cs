using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCube;
    [SerializeField]
    int numberOfCubesToSpawn = 25;
    [SerializeField]
    float spawnInterval = 1f;
    [SerializeField]
    float spawnAreaSize = 40f;

    private Coroutine spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
        StartSpawnLoop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartSpawnLoop();
        }
    }

    //spawn cube
    GameObject SpawnCube()
    {
        GameObject cube = Instantiate(prefabCube);
        cube.transform.position = new Vector3(Random.Range(-spawnAreaSize, spawnAreaSize), 2, Random.Range(-spawnAreaSize, spawnAreaSize));

        StartCoroutine(ChangeColor(cube));

        return cube;
    }

    IEnumerator ChangeColor(GameObject obj, float interval = 0.5f)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            obj.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    void StartSpawnLoop()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }

        spawnCoroutine = StartCoroutine(SpawnLoop());
    }

    void RestartSpawnLoop()
    {
        StopSpawnLoop();
        StartSpawnLoop();
    }

    void StopSpawnLoop()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    IEnumerator SpawnLoop()
    {
        int counter = 0;
        while (counter < numberOfCubesToSpawn)
        {
            counter += 1; // adds 1 to counter
            SpawnCube();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
