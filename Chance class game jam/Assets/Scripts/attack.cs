using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class attack : MonoBehaviour
{
    private BoxCollider hitbox;
    private MeshRenderer render;
    private Vector3 facingDirection;
    

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponentInChildren<BoxCollider>();
        render = GetComponentInChildren<MeshRenderer>();
        hitbox.enabled = false;
        
        transform.Rotate(0, -55.0f, 0, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        facingDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        facingDirection.Normalize();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (facingDirection != Vector3.zero)
            {
                transform.forward = facingDirection;
                transform.Rotate(0, -55.0f, 0, Space.Self);
            }
            StartCoroutine(Rotate());
        }
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
}
