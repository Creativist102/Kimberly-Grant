using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 40.0f;
    public float lowerBound = -10.0f;
    public float sideBounds = 30.0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }

        if(transform.position.x > sideBounds)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < -sideBounds)
        {
            Destroy(gameObject);
        }
    }
}
