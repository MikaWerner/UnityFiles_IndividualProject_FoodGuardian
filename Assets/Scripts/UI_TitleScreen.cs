using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_TitleScreen : MonoBehaviour
{
  public void PlayGame ()
    {
        Debug.Log("Game start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f; // add time delay of idk 4
    }

    public void QuitGame ()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
