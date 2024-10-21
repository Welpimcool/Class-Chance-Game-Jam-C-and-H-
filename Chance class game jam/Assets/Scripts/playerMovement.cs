using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public static GameObject instance;

    private void Awake() {
        instance = this.gameObject;
    }

    public float walkSpeed = 5f;
    private float curSpeed;
    private Rigidbody rb;
    public int health;
    public int maxHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
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

    void onHit(){
        Debug.Log("player hit");
        health -= 1;
        if (health <= 0) {
            die();
        }
    }
    void onHit(int damage){
        Debug.Log("player hit");
        health -= damage;
        if (health <= 0) {
            die();
        }
    }
    void die() {
        Debug.Log("player died :(");
    }
}
