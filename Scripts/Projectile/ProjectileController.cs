using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public ProjectileData data;

    float speed;
    private Rigidbody2D rgb;

	void Awake () {

        speed = data.speed;
        rgb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {

        rgb.velocity = new Vector2(speed * transform.localScale.x, 0);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerDrop playerDrop = collision.gameObject.GetComponent<PlayerDrop>();
            
           
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            player.hitted = true;

            if (player.points == 100)
            {
                playerDrop.DropIt();
            }
            Destroy(gameObject);
        }
    }
}
