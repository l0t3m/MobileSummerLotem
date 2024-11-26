using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadMainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    public void LoadGameplayScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay");
    }
}
