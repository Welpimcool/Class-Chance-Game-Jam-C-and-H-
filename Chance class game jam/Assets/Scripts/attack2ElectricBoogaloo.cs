using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack2ElectricBoogaloo : MonoBehaviour
{
    [SerializeField]private LayerMask layerMask;
    private Transform trans;
    private Vector3 facingDirection;
    [SerializeField] private float attackCooldown;
    private float currentCooldown;
    [SerializeField] private float[,] weaponPresets;
    private float damage;
    private float range;
    private int weapon;
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = attackCooldown;
        //Stats in order: [Damage, Speed, Range]
        weaponPresets = new float[,] { { 1, .4f, 2 }, { .75f, .25f, 1f }, { 2, .8f, 3 } };
        //weapon = UnityEngine.Random.Range(0, weaponPresets.Length);
        weapon = 0;
        damage = weaponPresets[weapon, 0];
        //attackCooldown = weaponPresets[weapon, 1];
        attackCooldown = 0;
        //range = weaponPresets[weapon, 2];
        range = 1;
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        facingDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        facingDirection.Normalize();
        //if (Input.GetKeyDown(KeyCode.Space) && currentCooldown >= attackCooldown)
        if (Input.GetKey(KeyCode.Space) && currentCooldown >= attackCooldown)
        {
            if (facingDirection != Vector3.zero)
            {
                testAttack();

            }
            currentCooldown = 0;
        }
        currentCooldown += Time.deltaTime;
    }
    public void testAttack()
    {
        RaycastHit hit;
        for (int i = 0; i < 1; i++)
        {

        }
        if (Physics.Raycast(trans.position, facingDirection, out hit, range*25, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            Debug.Log("based");
            
            
        }

        else Debug.Log("ima commit");
        Debug.DrawRay(trans.position, facingDirection, Color.yellow, 1);
        Debug.Log(trans.position + " " + facingDirection + " " + hit + " " + range * 25 + " " + layerMask);
    }
}
