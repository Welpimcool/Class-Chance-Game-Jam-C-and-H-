using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class enemySpawner : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject enemy;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            spawnEnemy();
        }
    }

    private void spawnEnemy() {
        int randomInt = UnityEngine.Random.Range(0,spawners.Length+1);
        Transform randomSpawner = spawners[randomInt];
        Instantiate(enemy, randomSpawner.position,randomSpawner.rotation);
    }

}
