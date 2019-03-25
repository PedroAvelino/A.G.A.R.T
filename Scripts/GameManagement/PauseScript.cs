using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public string mainMenu;

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

    #region Singleton
    public static PauseScript instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
    }
    #endregion

    private void Start()
    {
        SceneManager.sceneLoaded += ResetPause;

    }

    void Update()
    {

        if (Input.GetButtonDown("Start"))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void ResetPause(Scene scene, LoadSceneMode mode)
    {
        Resume();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
