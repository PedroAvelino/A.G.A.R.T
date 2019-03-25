using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    public bool jump = false;

    //Inputs
    public string horizontalButton;
    public string jumpButton;

    

    void Start () {

        this.enabled = false;
        controller = GetComponent<CharacterController2D>();
	}
	
	
	void Update () {

        horizontalMove = Input.GetAxisRaw(horizontalButton) * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown(jumpButton))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            if(controller.m_Grounded)
            AudioManager.instance.Play("Jump");
       
        }

        if (!controller.m_Grounded)
            animator.SetBool("isJumping", true);

	}

    private void FixedUpdate()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
