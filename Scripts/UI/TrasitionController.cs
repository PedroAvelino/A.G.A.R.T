using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrasitionController : MonoBehaviour
{
    #region Singleton
    public static TrasitionController instance;
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

    public Animator animator;

    private int levelToLoad;

    public void FadeOutToLevel()
    {
        animator.Play("FadeOut");
    }

    public void FadeInToLevel()
    {
        animator.Play("FadeIn");
    }

    public void OnFadeComplete()
    {
        SceneNavigationManager.instance.LoadNextScene();
    }
}
