using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScripttest : MonoBehaviour
{
    [System.Serializable]
    public class NameColorPair
    {
        public string name;
        public Color color;
    }

    [SerializeField]
    private NameColorPair[] nameColorPairs;

    [SerializeField]
    GameObject prefabCube;

    [SerializeField]
    int totalCubes = 25;

    [SerializeField]
    [Range(0.1f, 2f)]
    float spawnCubeInterval = 1f;

    [SerializeField]
    int spawnPositionRange = 40;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());

        Debug.Log("The first name in the array of names is " + nameColorPairs[0].name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(SpawnLoop());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(CollectCubes());
        }
    }

    // spawn cube
    GameObject SpawnCube()
    {
        GameObject cube = Instantiate(prefabCube);

        int randomIndex = Random.Range(0, nameColorPairs.Length);
        NameColorPair pair = nameColorPairs[randomIndex];

        cube.name = pair.name;

        cube.transform.position = new Vector3(
            Random.Range(-spawnPositionRange, spawnPositionRange),
            Random.Range(1.5f, 2.5f),
            Random.Range(-spawnPositionRange, spawnPositionRange));

        cube.GetComponent<Renderer>().material.color = pair.color;

        cube.AddComponent(typeof(Rigidbody));
        return cube;
    }

    // New CollectCubes Coroutine
    IEnumerator CollectCubes()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject cube in cubes)
        {
            Vector3 targetPosition = new Vector3(0, 2, 0);
            float moveDuration = 1.0f; // Adjust the duration as needed

            float elapsedTime = 0f;
            Vector3 initialPosition = cube.transform.position;

            while (elapsedTime < moveDuration)
            {
                cube.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the final position is exactly the target position
            cube.transform.position = targetPosition;
        }
    }

    // the loop function
    IEnumerator SpawnLoop()
    {
        int counter = 0;
        while (counter < totalCubes)
        {
            counter += 1;    // adds 1 to counter
            SpawnCube();
            yield return new WaitForSeconds(spawnCubeInterval);
        }
    }
}
