using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject slinger;
    public GameObject enemyHold;
    public GameObject menu;

    public bool birdDestroy;

    public Text SlingCount;
    Slingshot s;
    WinCondition hold;
    public void Start()
    {
        Time.timeScale = 1;
        LoseScreen.SetActive(false);
        WinScreen.SetActive(false);
        s = slinger.GetComponent<Slingshot>();
        hold = enemyHold.GetComponent<WinCondition>();
        birdDestroy = false;
    }

    private void Update()
    {
        if (s.count <= 0 && hold.check && birdDestroy) 
        {
            LoseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if (hold.check == false && s.count >= 0 && birdDestroy) 
        {
            PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex + 1);
            WinScreen.SetActive(true);
            Time.timeScale = 0;
        }

        SlingCount.text = s.count + "X";
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ReturnMenu()
	{
        SceneManager.LoadScene(0);
    }

    public void Retry()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    public void ShowMenu()
	{
        menu.SetActive(true);
	}
    public void CloseMenu()
	{
        menu.SetActive(false);
	}
}
