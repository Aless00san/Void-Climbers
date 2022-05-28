using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public static MouseOver instance;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnMouseOver()
    {
        HookScript.instance.hookable = true;
    }
    private void OnMouseExit()
    {
        HookScript.instance.hookable = false;
    }*/
}
