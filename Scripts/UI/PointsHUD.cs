using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHUD : MonoBehaviour
{
    [Header("Player")]
    [Tooltip("Vai tomar no seu cu")]
    public string playerName;
    public PlayerStats player;

    [Header("Image")]
    public Image pointUI;

    [Header("Sprites")]
    public Sprite[] sprites;

    private Sprite currentSprite;

    int spriteIndex;

    public void ResetValues()
    {
        spriteIndex = 0;
        player = GameObject.Find(playerName).GetComponent<PlayerStats>();
        Debug.Log(player);
    }

    void Update()
    {
        currentSprite = sprites[spriteIndex];

        spriteIndex = player.packegesDelivered;

        pointUI.sprite = currentSprite;
    }
}
