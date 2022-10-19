using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int scoreToGive;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        Explosion();
        scoreManager.IncreaseScore(scoreToGive);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    void Explosion()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
        explosionParticle.transform.parent = null;
    }
}

//Used on UFOs