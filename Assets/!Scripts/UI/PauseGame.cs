using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    private bool isPaused = false;



    private void Awake()
    {
        if (pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
        }
    }



    public void DoPause()
    {
        if (isPaused) // Paused => Active
        {
            Time.timeScale = 1;
            isPaused = false;

        }
        else // Active => Paused
        {
            Time.timeScale = 0;
            isPaused = true;
        }

        pausePanel.SetActive(isPaused);
    }
}
