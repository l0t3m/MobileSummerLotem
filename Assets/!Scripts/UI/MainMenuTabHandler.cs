using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuTabHandler : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject[] panels;

    void Start()
    {
        buttons[1].enabled = false;
    }

    public void PressTab(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            buttons[i].enabled = true;
            panels[i].SetActive(false);
        }
        buttons[index].enabled = false;
        panels[index].SetActive(true);
    }
}
