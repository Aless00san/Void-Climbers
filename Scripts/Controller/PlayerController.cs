using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    //jump things
  
    /*rivate bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public float jumpForce;
    public float jumpCounter = 0;*/
    //other things
    public float timeBetweenShots;
    private float shotCounter;
    public float moveSpeed;
    private Vector3 mousePos;
    private Vector2 moveInput;

    public Rigidbody2D rb;
    public Animator anim;
    public GameObject bulletToFire;
    public Transform firePoint;

    public bool canMove = true;
    public bool gun;
    public SpriteRenderer bodySR;
    public float activeMoveSpeed;
    private float jumpForce = 20.0f;

    private void Awake()
    { 
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = HookScript.instance.Cam.WorldToScreenPoint(transform.localPosition);
        Vector3 mousePos = Input.mousePosition;


   
        if (moveInput.x < 0) { bodySR.flipX = true; }
        if (moveInput.x > 0) { bodySR.flipX = false; }
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Fin del movimiento
        
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
           


