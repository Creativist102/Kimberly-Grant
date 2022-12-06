using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasFlag;
    public bool flagPlaced;


    void Start()
    {
        hasFlag = false;
        flagPlaced = false;
    }

    void Update()
    {
        if(flagPlaced)
        {
            WinGame();
        }
    }

//Actions
    public void PlaceFlag()
    {
        flagPlaced = true;
        hasFlag = false;
    }

//Final Scene
    public void WinGame()
    {
        Debug.Log("You've won! Have a cookie!");
        Time.timeScale = 0;
    }

    public void LoseGame()
    {
        Debug.Log("You've misplaced your flag. Try again?");

    }
}
