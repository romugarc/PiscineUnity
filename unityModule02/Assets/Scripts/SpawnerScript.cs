using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;

    private int currWave = 1;
    private float lastSpawn;
    private int enemiesAlive;
    private int enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = baseEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawn += Time.deltaTime;

        if (lastSpawn >= (1f / enemiesPerSecond))
        {
            Debug.Log("Spawn Enemy");
        }
    }
}
