using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackDelay;
    public float startDelay;
    public Transform attackPos;

    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackDelay <= 0)
        {
            if(Input.GetKey(KeyCode.X))
            {
                Collider2D[] enemyToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);

                for(int i=0; i<enemyToDamage.Length; i++)
                {
                    enemyToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            attackDelay = startDelay;
        }
        else
        {
            attackDelay -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
