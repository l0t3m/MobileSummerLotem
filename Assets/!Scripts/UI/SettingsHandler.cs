using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider audioSlider;
    [SerializeField] Button[] DifficultyButtons;
    [SerializeField] Button[] InputButtons;
    [SerializeField] Button[] MovementButtons;

    private void Start()
    {
        audioSlider.value = PlayerPrefs.GetFloat("SFX", 5f);
        audioMixer.SetFloat("MasterVolume", CalculateVolumeByNumber(audioSlider.value));
        ChangeDifficulty(PlayerPrefs.GetInt("Difficulty", 1));
        ChangeInput(PlayerPrefs.GetInt("Input", 0));
    }

    public void ChangeVolume(float num)
    {
        PlayerPrefs.SetFloat("SFX", num);
        audioMixer.SetFloat("MasterVolume", CalculateVolumeByNumber(num));
    }

    private float CalculateVolumeByNumber(float num)
    {
        return num * 10 - 80;
    }

    public void ChangeDifficulty(int num)
    {
        PlayerPrefs.SetInt("Difficulty", num);
        for (int i = 0; i < DifficultyButtons.Length; i++)
        {
            if (i == num)
                DifficultyButtons[i].interactable = false;
            else
                DifficultyButtons[i].interactable = true;
        }
    }

    public void ChangeInput(int num)
    {
        PlayerPrefs.SetInt("Input", num);
        for (int i = 0; i < InputButtons.Length; i++)
        {
            if (i == num)
                InputButtons[i].interactable = false;
            else
                InputButtons[i].interactable = true;
        }
        for (int i = 0; i < MovementButtons.Length; i++)
        {
            MovementButtons[i].gameObject.SetActive(num == 1);
        }
    }
}
