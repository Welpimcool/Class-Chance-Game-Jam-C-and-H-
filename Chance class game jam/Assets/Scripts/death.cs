using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    private Collider box;
    [SerializeField] public string a;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("uhhhhhhhhhh");
        if (other.CompareTag(a))
        {
            
            other.gameObject.GetComponent<Playermovement>().onHit(9999,null);
            
        }
    }
}
