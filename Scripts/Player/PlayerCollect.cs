using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour {


    public bool collecting = false;
    public bool inStation = false;

    //Numbers
    public int stationCollect = 5;

    //Inputs
    public string collectButton;

    //Classes
    private PlayerStats player;

    public GameObject station = null;

    //Anim
    public Animator anim;
	
	void Start () {
        player = GetComponent<PlayerStats>();
	}
	
	
	void Update () {

        if (Input.GetButton(collectButton))
        {
            collecting = true;
            anim.SetBool("isAbsorving", true);
        }
        else
        {
            collecting = false;
            anim.SetBool("isAbsorving", false);
        }

        if (inStation && Input.GetButtonDown(collectButton) && !station.GetComponent<StationController>().isEmpty)
        {
            station.GetComponent<StationController>().LosePoints(stationCollect);
            player.AddPoints(stationCollect);
            AudioManager.instance.Play("CollectFX");
        }

    }

    #region Collecting Objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "candy" && collecting && !player.maxed)
        {
            candyController candy = collision.gameObject.GetComponent<candyController>();
            player.AddPoints(candy.value);

            Destroy(collision.gameObject);

            AudioManager.instance.Play("CollectFX");
        }

        
        if (collision.gameObject.tag == "Station")
        {
            inStation = true;
            station = collision.gameObject;

            
        }

    }
    #endregion


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Drop" && collecting && !player.maxed)
        {
            PlayerDrop drop = GetComponent<PlayerDrop>();
            player.AddPoints(drop.dropCost);
            AudioManager.instance.Play("CollectFX");
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Station")
        {
            inStation = false;
            station = null;
        }
    }
}
