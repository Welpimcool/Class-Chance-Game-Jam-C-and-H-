using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class enemySpawner : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject enemy;
    public GameObject player;
    private int playerMapNum;
    public int myMapNum;

    void Start()
    {
        playerMapNum = player.GetComponent<teleportToMap>().mapNum;
    }
    // Update is called once per frame
    void Update()
    {
        playerMapNum = player.GetComponent<teleportToMap>().mapNum;
        if (myMapNum == playerMapNum+1) {
            if (Input.GetKeyDown(KeyCode.Q)) {
                        spawnEnemy();
            }
        }
        


    }

    private void spawnEnemy() {
        int randomInt = UnityEngine.Random.Range(0,spawners.Length);
        Transform randomSpawner = spawners[randomInt];
        Instantiate(enemy, randomSpawner.position,randomSpawner.rotation);
    }

}
