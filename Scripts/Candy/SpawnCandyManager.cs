using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCandyManager : MonoBehaviour {

    public int timeStartSpawn = 5;

    public GameObject candyPrefab;
    public GameObject[] spawnPoint;
    int index;

    private void Awake()
    {
        
    }

    void Start () {

        spawnPoint = GameObject.FindGameObjectsWithTag("candySpawn");
        index = spawnPoint.Length;

        InvokeRepeating("SpawnCandy", timeStartSpawn, 15f);

	}

    void SpawnCandy()
    {
        //GameObject candyClone =Instantiate(candyPrefab, spawnPoint[index].transform.position, spawnPoint[index].transform.rotation);

        foreach (GameObject points in spawnPoint)
        {
            GameObject candyClone = Instantiate(candyPrefab, points.transform.position, points.transform.rotation);
        }
    }
}
