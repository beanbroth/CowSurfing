using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawnerController : MonoBehaviour
{
    [SerializeField] Transform[] _lanes;

    [SerializeField] GameObject _debrisPrefab;

    [SerializeField] float maxTime = 5;
    [SerializeField] float minTime = 2;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;
    [SerializeField] Vector2 _spawnOffset;

    void Start()
    {
        spawnTime = Random.Range(minTime, maxTime);
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            SpawnObject();
            spawnTime = Random.Range(minTime, maxTime);
        }
    }


    //Spawns the object and resets the time
    void SpawnObject()
    {
        time = 0;
        Instantiate(_debrisPrefab, (Vector2)_lanes[Random.Range(0, 5)].position + _spawnOffset, Quaternion.identity, transform);
    }
}