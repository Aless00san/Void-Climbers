using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceController : MonoBehaviour
{
    public static ResourceController instance;

    public int score;
    public int health;

    public int maxHealth = 100;

    public float currentStamina;
    public float maxStamina;
    public float staminaLoss = 10f;

    public bool air;

    public bool staminaConsume = false;
    private void Awake()
    {
        instance = this;
        score = PlayerPrefs.GetInt("Score");
    }
    // Start is called before the first frame update
    void Start()
    {
        air = false;
        health = maxHealth;
        currentStamina = maxStamina;
        UIcontroller.instance.staminaSlider.maxValue = maxStamina;
        UIcontroller.instance.healthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }

        if (currentStamina <= 0)
        {
            currentStamina = 0;
            GrapplingGunRaycasthit2D.instance.theJoint.enabled = false;
            GrapplingGunRaycasthit2D.instance.line.enabled = false;
            GrapplingGunRaycasthit2D.instance.checker = true;
 
            air = false;
        }

        if (air == true)
        {
            currentStamina -= staminaLoss * Time.deltaTime;
            CharacterController2D.instance.anim.SetBool("IsWalking", false);
            CharacterController2D.instance.anim.SetBool("Air", true);
        }
        
        if (air == false)
        {
            currentStamina += staminaLoss * Time.deltaTime;
            CharacterController2D.instance.anim.SetBool("Air", false);
        }
        UIcontroller.instance.staminaSlider.value = currentStamina;
        UIcontroller.instance.healthSlider.value = health;

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
