using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider audioSlider;
    [SerializeField] Button[] DifficultyButtons;
    [SerializeField] Button[] InputButtons;
    [SerializeField] Button[] MovementButtons;
    public SettingsClass Settings { private set; get; }

    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/settings.txt"))
            Settings = new SettingsClass();
        else
            Settings = JsonUtility.FromJson<SettingsClass>(File.ReadAllText(Application.persistentDataPath + "/settings.txt"));
        ApplySettings();
        SaveSettings();
    }
    
    private void ApplySettings()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            audioSlider.value = Settings.SFX;
            audioMixer.SetFloat("MasterVolume", CalculateVolumeByNumber(audioSlider.value));
        }
        ChangeDifficulty(Settings.Difficulty);
        ChangeInput(Settings.Input);
    }

    private void SaveSettings()
    {
        string output = JsonUtility.ToJson(Settings);
        File.WriteAllText(Application.persistentDataPath + "/settings.txt", output);
        PlayerPrefs.SetFloat("SFX", Settings.SFX);
        PlayerPrefs.SetInt("Difficulty", Settings.Difficulty);
        PlayerPrefs.SetInt("Input", Settings.Input);
        PlayerPrefs.Save();
    }
    public void ChangeVolume(float num)
    {
        Settings.SFX = num;
        SaveSettings();
        audioMixer.SetFloat("MasterVolume", CalculateVolumeByNumber(num));
    }

    private float CalculateVolumeByNumber(float num)
    {
        return (num > 0) ? (num * 2 - 15) : -80;
    }

    public void ChangeDifficulty(int num)
    {
        Settings.Difficulty = num;
        SaveSettings();
        if (SceneManager.GetActiveScene().name == "Main")
        {
            for (int i = 0; i < DifficultyButtons.Length; i++)
            {
                if (i == num)
                    DifficultyButtons[i].interactable = false;
                else
                    DifficultyButtons[i].interactable = true;
            }
        }
    }

    public void ChangeInput(int num)
    {
        Settings.Input = num;
        SaveSettings();
        if (InputButtons.Length != 0)
        {
            for (int i = 0; i < InputButtons.Length; i++)
            {
                if (i == num)
                    InputButtons[i].interactable = false;
                else
                    InputButtons[i].interactable = true;
            }
            
        }
        else
        {
            for (int i = 0; i < MovementButtons.Length; i++)
            {
                MovementButtons[i].gameObject.SetActive(num == 1);
            }
        }
    }
}
