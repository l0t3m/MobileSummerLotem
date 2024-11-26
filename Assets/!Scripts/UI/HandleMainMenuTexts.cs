using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class HandleMainMenuTexts : MonoBehaviour
{
    [SerializeField] TMP_Text hsText;
    [SerializeField] TMP_Text coinText;
    void Start()
    {
        int highscore = 0;
        int coins = 0;    
        if (File.Exists(Application.persistentDataPath + "/highscore.txt"))        
            int.TryParse(File.ReadAllText(Application.persistentDataPath + "/highscore.txt"), out highscore);
        hsText.text = "Highscore:\n" + highscore;
        if (File.Exists(Application.persistentDataPath + "/coins.txt"))
            int.TryParse(File.ReadAllText(Application.persistentDataPath + "/coins.txt"), out coins);
        coinText.text = "Coins:\n" + coins;
    }
}
