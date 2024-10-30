using System.Collections;
using System.Collections.Generic;
using UnityEditor.Scripting;
using UnityEngine;

public class teleportToMap : MonoBehaviour
{
    [SerializeField] public GameObject[] test;
    public int offset = 5;
    public int mapNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test.length ="+test.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            nextMap();
            spawnEnemy(test[mapNum]);
        }
    }
    void teleport(GameObject location,int offset)
    {
        
        Debug.Log("tp position:" + location.transform.position.x +" "+ location.transform.position.y + offset +" "+ location.transform.position.z);
        transform.position = new Vector3 (location.transform.position.x, location.transform.position.y + offset, location.transform.position.z);
        Debug.Log("player position:" + transform.position.x +" "+ transform.position.y + offset +" "+ location.transform.position.z);
    }
    public int getMapNum() {
        return mapNum;
    }
    public void nextMap()
    {
        mapNum += 1;
        if (mapNum > test.Length - 1)
        {
            mapNum = 0;
        }
        teleport(test[mapNum], offset);
    }
    public void spawnEnemy(GameObject map)
    {
        for (int i = 0; i < UnityEngine.Random.Range(2, 6); i++)
        {
            map.GetComponentInChildren<enemySpawner>().spawnEnemy();
        }
    }
}
