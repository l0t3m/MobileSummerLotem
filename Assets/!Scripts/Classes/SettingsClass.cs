using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsClass
{
    public float SFX = 5.0f;
    public int Difficulty = 1;
    public int Input = 0;

    public SettingsClass()
    {
        SFX = 5.0f; Difficulty = 1; Input = 0;
        string output = JsonUtility.ToJson(this);
        File.Create(Application.persistentDataPath + "/settings.txt").Close();
        File.WriteAllText(Application.persistentDataPath + "/settings.txt", output);
    }
    public SettingsClass(float SFX, int Difficulty, int Input)
    {
        this.SFX = SFX;
        this.Difficulty = Difficulty;
        this.Input = Input;
    }
}
