using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    public static UnityEvent DamageEvent = new UnityEvent(); //Events communicating through different scripts
    public GameObject DeathScreen;
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    private void Start() //not manually setting max life
    {
        life = hearts.Length; //life is equal to the aray containing all th hearts
        DamageEvent.AddListener(TakeDamage); //listeners activated through "Invoke", meaning they will react on this event
    }
    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
        }
    }
    public void GameOver()
    {
       DeathScreen.SetActive(true);
       Time.timeScale = 0f;
    }

    public void TakeDamage()   //subtract heart upon damage
    {
        life -= 1; 
        Destroy(hearts[life].gameObject);
        if (life < 1)
        {
            Debug.Log("We deceased");
            GameOver();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
