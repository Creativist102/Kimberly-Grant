using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBlaster : MonoBehaviour
{
    public GameObject enemyLazerbolt;
    public Transform alienBlaster;

    public float startDelay = 3f;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AlienShoot", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AlienShoot()
    {
        Instantiate(enemyLazerbolt, alienBlaster.transform.position, enemyLazerbolt.transform.Rotation);
    }
}
