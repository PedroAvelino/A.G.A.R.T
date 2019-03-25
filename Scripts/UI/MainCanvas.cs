using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{

    #region Singleton
    public static MainCanvas instance;
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

    [Header("Classes")]
    public CountDown countdown;
    public MatchTimer matchTimer;
    public EventHandler eveHandler;

    public void ResetUI()
    {
        //Starting with the Match Timer
        matchTimer.ResetValues();


        //Then the Count Down
        countdown.ResetValues();

        // Points HUD
        PointsHUD[] playerPointUI = FindObjectsOfType<PointsHUD>();
        foreach (PointsHUD i in playerPointUI)
            i.ResetValues();

        //EventHandler
        eveHandler.ResetValues();
              
    }
}
