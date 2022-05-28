using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewCharController : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    public SpriteRenderer bodySR;
    float horizontalMove  = 0f;
    bool jump = false;
    private Vector2 moveInput;
    private void Start()
    {
        
    }

    private void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
 
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
