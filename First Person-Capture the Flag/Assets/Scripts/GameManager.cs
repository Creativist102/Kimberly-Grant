using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;

    public int scoreToWin;
    public int curScore;

    public bool gamePaused;


    void Awake()
    {
        //Set instance to this script instance = this;
    }

    void Start()
    {
        hasFlag = false;
        flagPlaced = false;

        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if(flagPlaced)
        {
            Debug.Log("You have placed a flag!");
            //AddScore();
        }

        if(Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        gamePaused = ! gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void PlaceFlag()
    {
        flagPlaced = true;
        //hasFlag = false;
    }

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
