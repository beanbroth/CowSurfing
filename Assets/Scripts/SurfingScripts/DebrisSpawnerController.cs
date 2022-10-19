using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DebrisSpawnerController : MonoBehaviour
{

    [SerializeField] GameObject _debrisContainer;
    [SerializeField] Transform[] _lanes;

    [SerializeField] GameObject _debrisPrefab;
    [SerializeField] List<GameObject> _allDebris = new List<GameObject>();

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
        GameManager.OnGameStateChanged += OnGameManagerStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameManagerStateChanged;
    }

    void OnGameManagerStateChanged(GameManager.GameState nextState)
    {
        if (nextState == GameManager.GameState.TrickScreen)
        {
            foreach (GameObject debris in _allDebris)
            {
                Destroy(debris);
            }
            _allDebris.Clear();
            _debrisContainer.SetActive(false);
            enabled = false;

        }

        if (nextState == GameManager.GameState.PlayingGame)
        {
            _debrisContainer.SetActive(true);
            enabled = true;
        }
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
        _allDebris.Add(Instantiate(_debrisPrefab, (Vector2)_lanes[Random.Range(0, 5)].position + _spawnOffset, Quaternion.identity, _debrisContainer.transform));
    }
}