using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip mainmenuMusic, gameMusic;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();   
        playMainMenuMusic();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    public void playMainMenuMusic()
    {
        anim.SetTrigger("MusicFadeIn");
        audioSource.clip = mainmenuMusic;
        audioSource.Play();
    }

    public void stopMainMenuMusic()
    {
        anim.SetTrigger("MusicFadeOut");
    }

    public void playGameMusic()
    {
        anim.SetTrigger("MusicFadeIn");
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

}
