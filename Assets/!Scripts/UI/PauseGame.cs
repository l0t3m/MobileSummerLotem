using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    public bool IsPaused { get { return isPaused; }}


    private void Awake()
    {
        isPaused = false;
        if (SceneManager.GetActiveScene().name == "Gameplay")
            DoPause(false);
        else
            DoPause(true);
    }

    public void DoPause()
    {
        DoPause(!isPaused);
    }

    public void DoPause(bool isPausedT)
    {
        isPaused = isPausedT;
        gameObject.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }
}
