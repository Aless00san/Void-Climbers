using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRegen : MonoBehaviour
{
    public int healValue;
    public bool canHeal;
    // Start is called before the first frame update
    void Start()
    {
        canHeal = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canHeal == true)
        {
            ResourceController.instance.currentStamina = ResourceController.instance.maxStamina;
            ResourceController.instance.health += healValue;
            canHeal = false;
            StartCoroutine(waiter());
            IEnumerator waiter()
            {
                GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(10);
                GetComponent<SpriteRenderer>().enabled = true;
                canHeal = true;
            }           
        }

    }
}
