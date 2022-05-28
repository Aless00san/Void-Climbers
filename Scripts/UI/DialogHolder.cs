using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController2D.instance.canMove = false;
            GrapplingGunRaycasthit2D.instance.checker = false;
            Instancer.instance.Text.SetActive(true);
            Instancer.instance.Back.SetActive(true);            
            StartCoroutine(waiter());
            IEnumerator waiter()
            {
                yield return new WaitForSeconds(5);
                Instancer.instance.Text.SetActive(false);
                Instancer.instance.Back.SetActive(false);
                Instancer.instance.Shadow.SetActive(false);
                CharacterController2D.instance.canMove = true;
            }
        }
    }
}

