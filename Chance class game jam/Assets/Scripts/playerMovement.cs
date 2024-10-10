using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    float curSpeed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        curSpeed = walkSpeed;        
        rb.velocity = new Vector3(
			Mathf.Lerp(0, Input.GetAxis("Horizontal")* curSpeed, 0.8f),
			rb.velocity.y,
			Mathf.Lerp(0, Input.GetAxis("Vertical")* curSpeed, 0.8f)
		);
    }
}
