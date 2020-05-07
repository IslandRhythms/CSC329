using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool SettingsMenu = false;
    public GameObject PauseMenuUI;

    public GameObject SettingsUI;


    void Start()
    {
       AudioListener.volume = PlayerPrefs.GetFloat("Volume",1f);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !SettingsMenu)
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Qutting Game");
        Application.Quit();

    }

    public void Settings()
    {
        PauseMenuUI.SetActive(false);
        SettingsMenu = true;
        SettingsUI.SetActive(true);

    }

    public void ExitSettings()
    {
        SettingsUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        SettingsMenu = false;
    }




}
