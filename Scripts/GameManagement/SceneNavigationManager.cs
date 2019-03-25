using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationManager : MonoBehaviour
{
    #region Singleton
    public static SceneNavigationManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    public void LoadNextScene()
    {
        TrasitionController.instance.FadeInToLevel();

        if (SceneManager.GetActiveScene().buildIndex == 3 &&
            GameManager.instance.player1Score > GameManager.instance.player2Score)
            SceneManager.LoadScene(4);
        else if(SceneManager.GetActiveScene().buildIndex == 3 &&
            GameManager.instance.player2Score > GameManager.instance.player1Score)
            SceneManager.LoadScene(5);
        else if(SceneManager.GetActiveScene().buildIndex == 3 &&
            GameManager.instance.player1Score == GameManager.instance.player2Score)
            SceneManager.LoadScene(6);
        else
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
