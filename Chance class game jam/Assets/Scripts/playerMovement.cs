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
    private int health;
    public int maxHealth = 5;
    public healthBar UIHealthBar;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        UIHealthBar.setMaxHealth(maxHealth);
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


        if (Input.GetKeyDown(KeyCode.O)) {
            onHit();
        } else if (Input.GetKeyDown(KeyCode.P)) {
            onHeal();
        }


    }








    public void onHit(){
        Debug.Log("player hit");
        health -= 1;
        UIHealthBar.setHealth(health);
        if (health <= 0) {
            die();
        }
    }
    public void onHit(int damage){
        Debug.Log("player hit");
        health -= damage;
        UIHealthBar.setHealth(health);
        if (health <= 0) {
            die();
        }
    }
    public void onHeal() {
        Debug.Log("player healed");
        health += 1;
        UIHealthBar.setHealth(health);
    }
    public void onHeal(int heal) {
        Debug.Log("player healed");
        health += heal;
        UIHealthBar.setHealth(health);
    }

    void die() {
        Debug.Log("player died :(");
    }
}
