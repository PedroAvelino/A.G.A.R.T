using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {

    private Rigidbody2D rgb;

    public float speedInX;
    public float speedInY;

    [Header("Player That threw the object")]
    public GameObject thrower = null;
	void Awake () {
        rgb = GetComponent<Rigidbody2D>();

	}

    private void Start()
    {
        rgb.velocity = new Vector2(speedInX * transform.localScale.x, speedInY);
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            thrower.GetComponent<PlayerStats>().PackageDelivered();
            Destroy(gameObject);
        }
    }
}
