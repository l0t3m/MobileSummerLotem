using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class LossHandler : MonoBehaviour
{
    public static LossHandler Instance;
    [SerializeField] Canvas normalCanvas;
    [SerializeField] Canvas lossCanvas;
    [SerializeField] TMP_Text csText;
    [SerializeField] TMP_Text hsText;


    private void Start()
    {
        Instance = this;
        lossCanvas.enabled = false;
    }

    public void OnDeath()
    {
        normalCanvas.enabled = false;
        lossCanvas.enabled = true;

        int currentScore = ScoreHandler.Instance.GetScore();
        csText.text = "SCORE: " + ScoreHandler.Instance.FormatScoreText(currentScore);

        int.TryParse(File.ReadAllText(Application.persistentDataPath + "/highscore.txt"), out int highScore);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            ScoreHandler.Instance.SaveHighScore();
        }
        hsText.text = "HIGHSCORE: " + ScoreHandler.Instance.FormatScoreText(highScore);

    }
}
