using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private int timeLeft = 5;
    public int currentTimeLeft;
    public Text countdownText;

    IEnumerator LoseTime()
    {
        while (true)
        {
            currentTimeLeft--;
            yield return new WaitForSeconds(1);
            countdownText.text = ("" + currentTimeLeft);
            

            if (currentTimeLeft == 0)
            {
                countdownText.text = "GO!!";
                StartMatch();

                yield return new WaitForSeconds(1);
                countdownText.text = "";
                StopCoroutine("LoseTime");
            }

        }

    }

    void StartMatch()
    {
        MatchTimer.instance.ready = true;
    }

    public void ResetValues()
    {
        currentTimeLeft = timeLeft;
        countdownText.text = ("" + currentTimeLeft);
        StartCoroutine("LoseTime");
    }
}
