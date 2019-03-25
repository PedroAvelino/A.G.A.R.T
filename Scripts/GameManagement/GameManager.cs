using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int currentLevel;

    public GameObject pauseUIGO;

    [Header("Classes")]
    public Timer timer;
    public SceneNavigationManager sceneNavMan;

    
    public static GameManager instance;

    public bool isEnglish;

    [Header("SCOREBOARD")]
    public int player1Score;
    public int player2Score;
    List<PlayerStats> playerList = new List<PlayerStats>();

    private void Awake()
    {
        #region Singleton
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        #endregion

        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    void Update()
    {
        if(currentLevel == 0)
            pauseUIGO.SetActive(false);
        else
            pauseUIGO.SetActive(true);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentLevel = scene.buildIndex;

        switch (currentLevel)
        {
            case 0:
                NonGameSceneSettings();

                player1Score = 0;
                player2Score = 0;

                AudioManager.instance.StopAllAudios();
                AudioManager.instance.Play("Menu Theme");
                break;

            case 1:
                GameSceneLoadSettings();

                AudioManager.instance.StopAllAudios();
                AudioManager.instance.Play("Level 1 Theme");
                CreateScore();
                
                break;

            case 2:
                GameSceneLoadSettings();

                AudioManager.instance.StopAllAudios();
                AudioManager.instance.Play("Level 2 Theme");
                break;

            case 3:
                GameSceneLoadSettings();

                AudioManager.instance.StopAllAudios();
                AudioManager.instance.Play("Level 3 Theme");
                break;

            case 4:
                NonGameSceneSettings();

                AudioManager.instance.StopAllAudios();
                AudioManager.instance.Play("Victory");
                break;

            case 5:
                NonGameSceneSettings();

                AudioManager.instance.StopAllAudios();
                AudioManager.instance.Play("Victory");
                break;

            case 6:
                NonGameSceneSettings();

                AudioManager.instance.StopAllAudios();
                AudioManager.instance.Play("Victory_Secret");
                break;
        }
    }

    void GameSceneLoadSettings()
    {
        timer.enabled = true;
        sceneNavMan.enabled = true;

        timer.MovementTimer();
        MainCanvas.instance.gameObject.SetActive(true);
        MainCanvas.instance.ResetUI();
    }

    void NonGameSceneSettings()
    {
        timer.enabled = false;
        sceneNavMan.enabled = false;

        MainCanvas.instance.gameObject.SetActive(false);
    }
    
    void CreateScore()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            playerList.Add(p.GetComponent<PlayerStats>());
        }

        Debug.Log(players);
    }

    public void UpdateScore(PlayerStats playerThatWon)
    {
        PlayerStats currentPlayer = playerList.Find(player => player.playerID == playerThatWon.playerID);

        if (currentPlayer.playerID == 1)
            player1Score++;

        else if (currentPlayer.playerID == 2)
            player2Score++;
        else
            return;
    }

}
