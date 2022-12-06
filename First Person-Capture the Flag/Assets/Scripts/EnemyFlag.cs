using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlag : MonoBehaviour
{
    private GameManager gm;
    private Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        render = GetComponent<Renderer>();
        render.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        gm.hasFlag = true;
        render.enabled = false;
    }
}
