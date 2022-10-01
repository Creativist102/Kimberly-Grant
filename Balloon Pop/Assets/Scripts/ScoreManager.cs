using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    public void IncreaseScoreText(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void DecreaseScoreText(int amount)
    {
        
    }
}
