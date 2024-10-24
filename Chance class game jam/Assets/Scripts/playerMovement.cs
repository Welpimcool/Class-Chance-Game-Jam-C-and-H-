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


    private Vector3 movement;

    public float cooldown = 3f;
    private float curCooldown;
    private bool dash;
    private bool fatigue;
    public float fatigueCool = 1f;
    private float fatigueCurCool;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        UIHealthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update() //Input
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.O)) {
            onHit();
        } else if (Input.GetKeyDown(KeyCode.P)) {
            onHeal();
        }


    }

    void FixedUpdate() { //movement
        curCooldown += 2f*Time.fixedDeltaTime;
        if (!dash && !fatigue && curCooldown > cooldown && Input.GetKey(KeyCode.LeftShift)) {
            Debug.Log("Dash start");
            dash = true;
            curCooldown = 0f;
        } else if (dash && curCooldown < cooldown) {
            //while dashing
        } else if (dash){
            Debug.Log("Dash end");
            dash = false;
            fatigue = true;
        }

        if(fatigue) {
            fatigueCurCool += 2f*Time.fixedDeltaTime;
            if (fatigueCurCool > fatigueCool) {
                fatigue = false;
                Debug.Log("Fatigue end");
                fatigueCurCool = 0f;
            }
        }

        
        
        if (dash) {
            curSpeed = walkSpeed*2;
        } else if (fatigue) {
            curSpeed = walkSpeed/2;
        } else {
            curSpeed = walkSpeed;
        }
            
        
        rb.MovePosition(rb.position + movement * curSpeed * Time.fixedDeltaTime);
    }





    public void onHit(){
        Debug.Log("player hit");
        health -= 1;
        UIHealthBar.setHealth(health);
        // rb.velocity = new Vector3(Input.GetAxis("Horizontal") * 3, 0, Input.GetAxis("Vertical") * 3) * -1;
        // Debug.Log(new Vector3(Input.GetAxis("Horizontal") * 3, 0, Input.GetAxis("Vertical") * 3) * -1);
        if (health <= 0) {
            die();
        }
    }
    public void onHit(Collider collision){
        Debug.Log("player hit");
        health -= 1;
        UIHealthBar.setHealth(health);
        // rb.velocity = new Vector3(Input.GetAxis("Horizontal") * 20, 0, Input.GetAxis("Vertical") * 20) * -1;
        // Debug.Log(new Vector3(Input.GetAxis("Horizontal") * 20, 0, Input.GetAxis("Vertical") * 20) * -1);
        if (health <= 0) {
            die();
        }
    }
    public void onHit(int damage, Collider collision){
        Debug.Log("player hit");
        health -= damage;
        UIHealthBar.setHealth(health);
        // rb.velocity = new Vector3(Input.GetAxis("Horizontal") * 3, 0, Input.GetAxis("Vertical") * 3) * -1;
        // Debug.Log(new Vector3(Input.GetAxis("Horizontal") * 3, 0, Input.GetAxis("Vertical") * 3) * -1);
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
