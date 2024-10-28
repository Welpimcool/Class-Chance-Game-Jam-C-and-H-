using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{

    [SerializeField] public string tag;
    void OnCollisionEnter(Collider collision)
    {
        Debug.Log("uhhhhhhhhhh");
        if (collision.CompareTag(tag))
        {
            collision.gameObject.GetComponent<Playermovement>().onHit();
            
        }
    }
}
