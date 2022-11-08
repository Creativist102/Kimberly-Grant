using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;
    public Rigidbody2D rb;
    public float bounds = 30f;

    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;      //This is currently only working if facing right. Can't reference "isFacingRight"
    }

    void Update()
    {
        //if(gameObject.position.x >= bounds) Destroy(gameObject);
        //if(gameObject.position.x <= -bounds) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GhostEnemy ghostEnemy = other.GetComponent<GhostEnemy>();
        if(other.gameObject.CompareTag("Enemy"))
        {
            ghostEnemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
