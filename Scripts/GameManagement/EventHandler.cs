using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    #region Singleton
    public static EventHandler instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public Text resultText;

    public void StopMovement(GameObject playerThatWon)
    {
        if (playerThatWon)
        {
            PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();

            foreach (PlayerMovement player in players)
            {
                player.enabled = false;

            }

            resultText.text = "FINISH";
            StartCoroutine(ShowResults(playerThatWon));
            BinController.instance.DeactivateColliders();
            MatchTimer.instance.ready = false;
        }



        if(!playerThatWon)
        {
            resultText.text = "FINISH";
            BinController.instance.DeactivateColliders();
            MatchTimer.instance.ready = false;

            CheckWhoWon();

        }
    }

    void CheckWhoWon()
    {
        PlayerStats[] players = FindObjectsOfType<PlayerStats>();

        

        int max = 0;
        GameObject nameOfPlayer = null;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].packegesDelivered > max)
            {
                max = players[i].packegesDelivered;

                nameOfPlayer = players[i].gameObject;

            }
        }

        if (max != 0)
        {
            StartCoroutine(ShowResults(nameOfPlayer));
        }
        else
        {
            StartCoroutine("ShowDrawResults");
        }
        
        
    }

    IEnumerator ShowResults(GameObject playerThatWon)
    {
        yield return new WaitForSeconds(3);

        resultText.text = playerThatWon.name + " WINS";

        yield return new WaitForSeconds(3);

        //Trabalhar o wait for input
        LoadNextLevel();
    }

    IEnumerator ShowDrawResults()
    {
        yield return new WaitForSeconds(3);

        resultText.text = "DRAW";

        yield return new WaitForSeconds(3);

        //Trabalhar o wait for input
        LoadNextLevel();

    }

    public void ResetValues()
    {
        StopAllCoroutines();
        resultText.text = "";
    }

    void LoadNextLevel()
    {
        TrasitionController.instance.FadeOutToLevel();
    }

}
