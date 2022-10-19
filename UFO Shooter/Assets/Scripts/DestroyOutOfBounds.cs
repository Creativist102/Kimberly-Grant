using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30.0f;
    public float lowerBound = -5.0f;
    public float sideBounds = 30.0f;

    private ScoreManager scoreManager;
    private DetectCollisions detectCollisions;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        detectCollisions = GetComponent<DetectCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBound)
        {
            scoreManager.DecreaseScore(detectCollisions.scoreToGive);
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

//Used on UFOs, LAZERBOLTs