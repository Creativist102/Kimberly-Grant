using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBounds : MonoBehaviour
{
    public float sideBounds = 20f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if(player.position.x > sideBounds)
        {
            Destroy(gameObject);
        }

        if(player.position.x < -sideBounds)
        {
            Destroy(gameObject);
        }*/
    }
}
