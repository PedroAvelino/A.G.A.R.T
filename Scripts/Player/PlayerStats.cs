using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class PlayerStats : MonoBehaviour
{ 

    [Header("Score")]
    public int points;
    public int packegesDelivered;
    internal int pointMax = 100;

    [Header("Status")]
    public bool maxed = false;
    public bool hitted = false;

    [Header("Gauge Bars")]
    public Image gaugeBar;

    //Classes
    private PlayerMovement movement;

    //
    public Animator animator;

    //
    public Color colorFull;
    private Color originalColor;

    public int playerID;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        originalColor = gaugeBar.color;

    }

    void Update()
    {

        #region Point Management
        if (points >= pointMax)
        {
            points = pointMax;
            gaugeBar.color = colorFull;
            
            maxed = true;
        }
        else
        {
            maxed = false;
            gaugeBar.color = originalColor;
        }
        #endregion

        if (hitted)
        {
            points = 0;
            hitted = false;

            Stunned(3f);
        }


        
        if (packegesDelivered == 3)
        {
            EventHandler.instance.StopMovement(this.gameObject);
            GameManager.instance.UpdateScore(this);
            packegesDelivered++;
            
        }

    }

    public void AddPoints(int pointAmount)
    {
        points += pointAmount;
        if(pointAmount >= pointMax)
            AudioManager.instance.Play("Full");
        FillGauge();
    }

    public void LosePoints(int pointAmount)
    {
        points -= pointAmount;
        FillGauge();
    }

    public void MoveAgain()
    {
        movement.enabled = true;
        animator.SetBool("isStunned", false);
    }

    public void Stunned(float stunAmount)
    {
        movement.enabled = false;
        Rigidbody2D rgb = GetComponent<Rigidbody2D>();
        rgb.velocity = new Vector2(0f, 0f);
        animator.SetBool("isStunned", true);

        Invoke("MoveAgain", stunAmount);

    }

    private void FillGauge()
    {
        gaugeBar.fillAmount = (float)points / pointMax;
    }

    public void PackageDelivered()
    {
        packegesDelivered++;

        CameraShake.instance.Shake();

        AudioManager.instance.Play("Crowd Chant");

    }
}
