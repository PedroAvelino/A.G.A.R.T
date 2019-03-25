using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationController : MonoBehaviour
{

    public Sprite[] stationSprite;
    SpriteRenderer currentSprite;

    int index;

    //Stats
    public int currentPoints;
    public int maxPoints = 20;
    public float timeUntilNextWave = 5f;
    public bool isEmpty = false;

    void Start()
    {

        currentPoints = maxPoints;

        index = stationSprite.Length;
        currentSprite = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        switch (currentPoints)
        {
            case 20: currentSprite.sprite = stationSprite[0];
                break;
            case 15: currentSprite.sprite = stationSprite[1];
                break;
            case 10: currentSprite.sprite = stationSprite[2];
                break;
            case 5: currentSprite.sprite = stationSprite[3];
                break;
            case 0: currentSprite.sprite = stationSprite[4];
                break;

        }
    }
    private void FillPoints()
    {

        currentPoints = maxPoints;
        isEmpty = false;
    }

    public void LosePoints(int takeValue)
    {
        currentPoints -= takeValue;
        if (currentPoints <= 0)
        {
            isEmpty = true;
            Invoke("FillPoints", timeUntilNextWave);
        }
    }
}
