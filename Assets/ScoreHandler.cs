using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance;
    private TextMeshProUGUI ScoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Instance = this;
        ScoreText = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("AddTimeToScore", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddTimeToScore()
    {
        AddToScore(1);
        UpdateScoreText();
    }

    public void AddToScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        ScoreText.text = "SCORE: " + score;
    }
}
