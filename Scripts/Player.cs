using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#
public class Player : MonoBehaviour
{
    [Header("Player ID")]
    public PlayerIndex playerIndex;
    bool playerIndexSet = false;
    internal GamePadState state;
    internal GamePadState prevState;

    private void Update()
    {

        #region Settings
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }
        #endregion

        prevState = state;
        state = GamePad.GetState(playerIndex);
    }
}﻿