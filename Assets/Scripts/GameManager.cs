using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public AudioManager audioManager;
   [SerializeField] private EventSystem uiEventSystem; 

    [Header("Main Menu")]
    public bool inMenu = true;
    public GameObject startMenu;
    public GameObject tutorial;
    public GameObject credits;
    public Button startButton;
    public Button tutorialButton;
    public Button closetutorialButton;
    public Button creditButton;
    public Button closecreditButton;
    public Button quitButton;  
    public AudioClip uiClickSFX; 

    [Header("Game Over")]
    public GameObject gameOverscreen; 
    public TextMeshProUGUI gameOverscore;
    public Button returntoMenu;
    public Button replayButton;

    [Header("Core Game Loop")]
    public bool gameStart = false;
    public AudioClip loseSFX;
    public float ballRespawntimer;
    public AudioClip ballRespawnSFX;
    public float frogTimer;
    public bool isSheesh = false;
    public PlayerController playerController;
    public GameObject GameUI, PlungerUI;
    public TextMeshProUGUI ballCounter, scoreCounter;
    public GameObject frog;
    public float lives = 3;
    public float score = 0;
    public bool gameOver = false;
    public AudioClip sheesh;
    public AudioSource audioSource;
    public GameObject ball;
    public GameObject ballRespawn;
    public float ballBounciness;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        GameUI.GetComponent<CanvasGroup>().alpha = 0;
        GameUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        PlungerUI.GetComponent<CanvasGroup>().alpha = 0;
        PlungerUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        tutorial.GetComponent<CanvasGroup>().alpha = 0;
        credits.GetComponent<CanvasGroup>().alpha = 0;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = false;
       //tutorial.GetComponent<CanvasGroup>().interactable = false;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 0;
        //gameOverscreen.GetComponent<CanvasGroup>().interactable = false;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        audioSource = GetComponent<AudioSource>();
        frog.SetActive(false);
        uiEventSystem = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter.text = "Sheesh Points: " + score.ToString();
        ballCounter.text = "Balls Left: " + lives.ToString();
        if(gameOver)
        {
            score = 0;
        }

        if(score % 500 == 0 && score > 0)
        {
            isSheesh = true;
        }

        if(isSheesh)
        {
            audioSource.PlayOneShot(sheesh, 1f);
            isSheesh = false;
        }
    }

    public void GameOver()
    {
        uiEventSystem.firstSelectedGameObject = replayButton.gameObject;
        gameStart = false;
        GameUI.GetComponent<CanvasGroup>().alpha = 0;
        GameUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        PlungerUI.GetComponent<CanvasGroup>().alpha = 0;
        PlungerUI.GetComponent<CanvasGroup>().blocksRaycasts = false;        
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 1;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = true;  
        gameOverscreen.GetComponent<CanvasGroup>().interactable = true;       
        gameOverscore.text = "Sheesh Points: " + score.ToString();
        audioSource.PlayOneShot(sheesh, 1f);
    }

    public IEnumerator ballRespawnTimer()
    {      
        audioSource.PlayOneShot(loseSFX,1f);      
        while(ballRespawntimer > 0)
        {
           yield return new WaitForSeconds(ballRespawntimer); 
           ballRespawntimer--;
        } 
        frogTimer = 0.5f;
        audioSource.PlayOneShot(ballRespawnSFX, 1f);           
        ballRespawntimer = 0;
        ball.transform.position = ballRespawn.transform.position;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        frog.SetActive(true);
        print("froggy");
        StartCoroutine(ribbitFrog());
        ball.GetComponent<SphereCollider>().material.bounciness = ballBounciness;       
     }

     private IEnumerator ribbitFrog()
     {         
         while(frogTimer > 0)
         {
             yield return new WaitForSeconds(frogTimer);
             frogTimer--;
         }
         frog.SetActive(false);
     }

//Menu Stuff
    public void StartGame()
    {
        uiEventSystem.firstSelectedGameObject = startButton.gameObject;
        gameStart = true;
        inMenu = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 0;    
        startMenu.GetComponent<CanvasGroup>().interactable = false;     
        PlungerUI.GetComponent<CanvasGroup>().alpha = 1;
        PlungerUI.GetComponent<CanvasGroup>().blocksRaycasts = true;     
        GameUI.GetComponent<CanvasGroup>().alpha = 1;   
        audioSource.clip = uiClickSFX;
        audioSource.Play(); 
        audioManager.stopMainMenuMusic();
        audioManager.anim.SetTrigger("MusicFadeIn");
        audioManager.playGameMusic(); 
   }

    public void Tutorial()
    {
        uiEventSystem.firstSelectedGameObject = tutorialButton.gameObject;
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().interactable = false;
        tutorial.GetComponent<CanvasGroup>().alpha = 1;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = true;
        tutorial.GetComponent<CanvasGroup>().interactable = true; 
        GameUI.GetComponent<CanvasGroup>().alpha = 0;
        GameUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameUI.GetComponent<CanvasGroup>().interactable = false; 
        gameOver = false;
        audioSource.clip = uiClickSFX;
        audioSource.Play();
    }

    public void CloseTutorial()
    {
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        tutorial.GetComponent<CanvasGroup>().alpha = 0;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        startMenu.GetComponent<CanvasGroup>().interactable = true; 
        audioSource.clip = uiClickSFX;
        audioSource.Play();
    }

    public void Credits()
    {  
        credits.GetComponent<CanvasGroup>().alpha = 1;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = true;
        credits.GetComponent<CanvasGroup>().interactable = true;       
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().interactable = false; 
        
        uiEventSystem.firstSelectedGameObject = closecreditButton.gameObject;
        audioSource.clip = uiClickSFX;
        audioSource.Play();
    }

    public void CloseCredits()
    {
        credits.GetComponent<CanvasGroup>().alpha = 0;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        startMenu.GetComponent<CanvasGroup>().interactable = false; 
        audioSource.clip = uiClickSFX;
        audioSource.Play();
    }
    public void ReplayGame()
    {
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 0;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameOverscreen.GetComponent<CanvasGroup>().interactable = false; 
        PlungerUI.GetComponent<CanvasGroup>().alpha = 1;
        PlungerUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameUI.GetComponent<CanvasGroup>().alpha = 1;
        GameUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameOver = false;
        gameStart = true;
        lives = 3;
        score = 0;
        ball.transform.position = ballRespawn.transform.position;
        audioSource.clip = uiClickSFX;
        audioSource.Play();
    }

    public void QuitGame()
    {
        audioSource.clip = uiClickSFX;
        audioSource.Play();
        Application.Quit();
    }

    // GameOver

    public void ReturntoMenu()
    {
        GameUI.GetComponent<CanvasGroup>().alpha = 0;
        GameUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 0;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1; 
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = true; 
        startMenu.GetComponent<CanvasGroup>().interactable = true; 
        inMenu = true;
        gameStart = false;
        audioManager.playMainMenuMusic();
        audioSource.clip = uiClickSFX;
        audioSource.Play();
    }

}
