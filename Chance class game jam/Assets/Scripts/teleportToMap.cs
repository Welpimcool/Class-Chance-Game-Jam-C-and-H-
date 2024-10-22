using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportToMap : MonoBehaviour
{
    [SerializeField] public GameObject[] test;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            teleport(test[0]);
        }
    }
    void teleport(GameObject location)
    {
        transform.position = new Vector3 (location.transform.position.x, 0f, location.transform.position.y);
    }
}
