using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour {

    //Instances
    public GameObject projectile;
    public Transform spawnPoint;

    public string dropButton;

    //Classes
    private PlayerStats player;

    //Numbers
    internal int dropCost = 100;
	
	void Start () {

        player = GetComponent<PlayerStats>();
	}
	
	void Update () {

        if (Input.GetButtonDown(dropButton) && player.points >= dropCost)
        {
            DropIt();
            AudioManager.instance.Play("Drop");
        }
	}

    public void DropIt()
    {
        GameObject projectileClone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        projectileClone.transform.localScale =  transform.localScale.normalized;
        projectileClone.GetComponent<DropController>().thrower = gameObject;
        player.LosePoints(dropCost);
    }
}
