using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpikes : MonoBehaviour
{
    public static FallSpikes instance;
    public bool shouldFall;

    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFall == true && gameObject.transform.position.x == CharacterController2D.instance.gameObject.transform.position.y)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            gameObject.transform.GetComponent<Rigidbody2D>().freezeRotation = true;
        } 
    }
}
