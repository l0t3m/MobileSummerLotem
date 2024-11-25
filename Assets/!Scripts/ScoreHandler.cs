using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI CoinText;
    private ScoreClass score;
    private ScoreClass coin;


    void Start()
    {
        Instance = this;
        Instance.score = new ScoreClass();
        Instance.coin = new ScoreClass();
        InvokeRepeating("AddTimeToScore", 0, 0.2f / (PlayerPrefs.GetInt("Difficulty", 1) + 1));
    }

    private void AddTimeToScore()
    {
        AddToScoreClass(1, true);
    }

    public void AddToScoreClass(int amount, bool toScore = true)
    {
        if (toScore)
            Instance.score.Add(amount);
        else
        {
            Instance.coin.Add((int)Mathf.Pow(2, PlayerPrefs.GetInt("Difficulty", 1)));
        }
        UpdateAllText();
    }

    public string FormatScoreText(int var)
    {
        string text = var.ToString();
        string ret = "";

        if (text.Length < 6)
        {
            int zero = 6 - text.Length;

            for (int i = 0; i < zero; i++)
                ret += "0";
        }
        ret += text;
        return ret;
    }

    private void UpdateAllText()
    {
        ScoreText.text = FormatScoreText((int)Instance.score.value);
        CoinText.text = Instance.coin.value.ToString();
    }

    public void SaveHighScore()
    {
        string scorePath = Application.persistentDataPath + "/highscore.txt";
        if (!File.Exists(scorePath))
            File.Create(scorePath).Close();

        File.WriteAllText(scorePath, score.value.ToString());
    }

    public int GetScore()
    {
        return Instance.score.value;
    }
}
