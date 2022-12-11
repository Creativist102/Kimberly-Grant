using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    public int curHP;
    public int maxHP;
    public int scoreToGive;

    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;

    private List<Vector3> path;

    //private Weapon weapon;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //weapon = GetComponent<Weapon>();
        target = FindObjectOfType<PlayerControlls>().gameObject;
        InvokeRepeating("UpdatePath", 0f, 0.5f);

        curHP = maxHP;
    }

    // Update is called once per frame
    void UpdatePath()
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;

        if(curHP <= 0)
            Expire();
    }

    public void Expire()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;

        float dist = Vector3.Distance(transform.position, target.transform.position);

        if(dist <= attackRange)
        {
            /*if(weapon.CanShoot())
                weapon.Shoot();*/
        }
        else
        {
            ChaseTarget();
        }
    }
}
