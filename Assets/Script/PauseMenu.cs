using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject GlobalVariable;
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GlobalVariable.GetComponent<GlobalVariable>().GameIsPaused = 0;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GlobalVariable.GetComponent<GlobalVariable>().GameIsPaused = 1;
    }

    public void goToMenu()
    {
        Time.timeScale = 1f;
        GlobalVariable.GetComponent<GlobalVariable>().GameIsPaused = 0;
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
