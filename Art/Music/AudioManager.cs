using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource levelMusic;

    public AudioSource hit, pickup;
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

    public void PlayGameOver()
    {
        levelMusic.Stop();

    }

    public void PlayLevelWin()
    {
        levelMusic.Stop();
    }

    public void PlayHit()
    {
        hit.Play();
    }

    public void PlayPickup()
    {
        pickup.Play();
    }

}
