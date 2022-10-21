using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHat : MonoBehaviour
{
    /*
    public bool wearingHat = false;

    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Update()
    {

    }
    */

    void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory manager = collision.GetComponent<Inventory>();
        if(manager)
        {
            bool pickedUp = manager.PickupItem(gameObject);
            
            if(pickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
