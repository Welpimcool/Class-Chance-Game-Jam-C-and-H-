using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyAi : MonoBehaviour
{
    public float maxHealth = 5;
    private float health;
    private GameObject destination;
    public NavMeshAgent agent;
    public Rigidbody body;
    public CapsuleCollider capsule;
    public string weaponTag;
    public string playerTag;
    // public Bullet bulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Running");
        agent = GetComponent<NavMeshAgent>();
        body = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        destination = Playermovement.instance;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = destination.transform.position;
    }

    void OnTriggerEnter(Collider collision) {
        Debug.Log("trigger entered");
        if (collision.gameObject.tag == weaponTag) {
            onHit(collision.gameObject.GetComponentInParent<attack>().getDamage());
        }
        if (collision.gameObject.tag == playerTag) {
            onAttack(collision);
        }
    }

    void onHit(){
        Debug.Log("enemy hit");
        health -= 1;
        if (health <= 0) {
            die();
        }
    }
    void onHit(float damage){
        health -= damage;
        if (health <= 0) {
            die();
        }
    }

    void onAttack(Collider collision) {
        collision.gameObject.GetComponent<Playermovement>().onHit(collision);
    }

    void onAttack(Collider collision,int damage) {
        collision.gameObject.GetComponent<Playermovement>().onHit(damage,collision);
    }



    void die() {
        Debug.Log("enemy died");
        Destroy(gameObject);
    }
}
