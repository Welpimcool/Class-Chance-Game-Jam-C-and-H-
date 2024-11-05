using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class attack : MonoBehaviour
{
    private BoxCollider hitbox;
    private MeshRenderer render;
    private Vector3 facingDirection;
    [SerializeField]private float attackCooldown;
    private float currentCooldown;
    [SerializeField] private float[,] weaponPresets;
    private float damage;
    private float range;
    private int weapon;
    

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponentInChildren<BoxCollider>();
        render = GetComponentInChildren<MeshRenderer>();
        hitbox.enabled = false;
        currentCooldown = attackCooldown;
        //Stats in order: [Damage, Speed, Range]
        weaponPresets = new float[,] { {1, .4f, 2}, {  .75f, .25f, 1f}, {2, .8f, 3} };
        weapon = UnityEngine.Random.Range(0, weaponPresets.Length);
        damage = weaponPresets[weapon, 0];
        attackCooldown = weaponPresets[weapon, 1];
        range = weaponPresets[weapon, 2];


        transform.Rotate(0, -55.0f, 0, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
        facingDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        facingDirection.Normalize();
        if (Input.GetKeyDown(KeyCode.Space) && currentCooldown >= attackCooldown)
        {
            if (facingDirection != Vector3.zero)
            {
                transform.forward = facingDirection;
                transform.Rotate(0, -55.0f, 0, Space.Self);
            }
            currentCooldown = 0;
            StartCoroutine(Rotate());
        }
        currentCooldown += Time.deltaTime;
        
    }
    IEnumerator Rotate()
    {
        render.enabled = true;
        hitbox.enabled = true;
        for (int i = 0; i <22; i++)
        {
            transform.Rotate(0, 5.0f, 0, Space.Self);
            yield return new WaitForSeconds(.01f);
        }
        render.enabled = false;
        hitbox.enabled = false;
        transform.Rotate(0, -110.0f, 0, Space.Self);
    }
    public float getDamage() 
    {
        return damage;
    }
    public float getAttackSpeed()
    {
        return attackCooldown;
    }
    public float getRange()
    {
        return range;
    }
}
