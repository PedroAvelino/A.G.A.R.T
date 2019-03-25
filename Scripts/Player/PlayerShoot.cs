using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    
    //Instances
    public Rigidbody2D projectile;
    public Transform spawnShot;

    //Cooldown
    public float coolDown = 5;
    float coolDownT;

    //Classes
    private PlayerStats player;

    //Input
    public string shootButton;

    //Numbers
    int shotCost = 20;

    //
    public Animator animator;

	void Start () {

        player = GetComponent<PlayerStats>();

	}
	
	
	void Update () {

        #region Cooldown Time
        if (coolDownT > 0)
        {
            coolDownT -= Time.deltaTime;
        }

        if (coolDownT <= 0)
        {
            coolDownT = 0;
        }
        #endregion

        if (Input.GetButtonDown(shootButton) && coolDownT == 0 && player.points >= shotCost)
        {
            Shot(projectile);
            coolDownT = coolDown;
            animator.SetBool("isShooting", true);
            
        }
        else
        {
            animator.SetBool("isShooting", false);
        }

    }

    public void Shot(Rigidbody2D objecToShoot)
    {
        Rigidbody2D projectileClone = Instantiate(objecToShoot, spawnShot.position, spawnShot.rotation);
        projectileClone.transform.localScale = transform.localScale;
        player.LosePoints(shotCost);

        AudioManager.instance.Play("Shot");

        
    }
}
