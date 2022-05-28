using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public GameObject image;
    public bool needImage, endLevel = false;
    public int cCount;
    public string levelName;
    public static UIcontroller instance;
    public Slider staminaSlider, healthSlider;

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
        if (Input.GetMouseButtonDown(0) && endLevel == true)
        {
            cCount += 1;
            if (needImage == true) {
                image.SetActive(true);
            }
            GameObject.Find("EndText").GetComponentInChildren<Text>().text = "You know... I used to be like you";
            if (cCount == 2)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "Searching for treasures all around the world";
            }
            if (cCount == 3)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "Until I arrived here";
            }
            if (cCount == 4)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "I was trapped inside this mountain until you arrived";
            }
            if (cCount == 5)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "The treasure was cursed and trapped everybody who entered this place";
            }
            if (cCount == 6)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "And the only way to be free... Is trapping someone else";
            }
            if (cCount == 7)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "I'm sorry...";
            }
            if (cCount == 8)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "";
                StartCoroutine(waiter());
                IEnumerator waiter()
                {
                    yield return new WaitForSeconds(5);
                    SceneManager.LoadScene(levelName);
                }
            }
            if (cCount == 9)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "";
            }
            if (cCount >= 10)
            {
                GameObject.Find("EndText").GetComponentInChildren<Text>().text = "";
            }
        }
    }
}
