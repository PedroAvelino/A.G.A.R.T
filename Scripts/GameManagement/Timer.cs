using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    void EnableMovement()
    {
        PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();

        foreach(PlayerMovement player in players){

            player.enabled = true;
            Debug.Log("Test Timer");
        }
    }

    public void MovementTimer()
    {
        StopCoroutine("EnablePlayerMovement");
        StartCoroutine("EnablePlayerMovement");
    }

    IEnumerator EnablePlayerMovement()
    {
        yield return new WaitForSeconds(5);
        PlayerMovement[] players = FindObjectsOfType<PlayerMovement>();

        foreach (PlayerMovement player in players)
        {
            player.enabled = true;
        }
    }
}
