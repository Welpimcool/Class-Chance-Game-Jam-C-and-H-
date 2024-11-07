using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weaponStats : MonoBehaviour
{
    private float range;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getStats());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator getStats() 
    {
        yield return new WaitForSeconds(0.5f);
        range = GetComponentInParent<attack>().getRange();
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * range);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (0.5f * 3 * range));
        Debug.Log("eq" + (0.5f * 3 * range));
    }
}
