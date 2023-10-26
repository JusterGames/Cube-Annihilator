using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float zRange = 2;
    public float xRange = 2;
    public float heightmin = 2;
    public float heightmax = 2;
    public int numOfItemsToSpawn = 10;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ItemSpawner is starting up");
        for(int i=0; i<numOfItemsToSpawn; i++)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        Debug.Log("Spawning Item");
        GameObject item = Instantiate(itemPrefab);
        item.transform.Translate(Random.Range(-xRange, xRange), Random.Range(heightmin, heightmax), Random.Range(-zRange, zRange));
    }
    
    
        
   
}
