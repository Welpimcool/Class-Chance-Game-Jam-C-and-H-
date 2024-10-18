using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    float curSpeed;
    Rigidbody rb;
    Vector3 movementDirection;
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
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementDirection.Normalize();
        if(movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }
            
    }
}
