using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject continueButton;

	void Update()
    {
        if(PlayerPrefs.GetInt("LastLevel") !=0)
            continueButton.SetActive(true);
        else
            continueButton.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteKey("LastLevel");
    }
    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel"));
    }
}
