using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject startMenu;
    public GameObject tutorial;
    public GameObject credits;
    public Button startButton;
    public Button tutorialButton;
    public Button closetutorialButton;
    public Button creditButton;
    public Button closecreditButton;
    public Button quitButton;   

    [Header("Game Over")]
    public GameObject gameOverscreen; 
    public TextMeshProUGUI gameOverscore;
    public Button returntoMenu;

    [Header("Core Game Loop")]
    public bool gameStart = false;
    public float ballRespawntimer;
    public PlayerController playerController;
    public GameObject GameUI;
    public TextMeshProUGUI ballCounter, scoreCounter;
    public float lives = 3;
    public float score = 0;
    public bool gameOver = false;
    public GameObject ball;
    public GameObject ballRespawn;
    public float ballBounciness;
    // Start is called before the first frame update
    void Start()
    {
        GameUI.GetComponent<CanvasGroup>().alpha = 0;
        GameUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        tutorial.GetComponent<CanvasGroup>().alpha = 0;
        credits.GetComponent<CanvasGroup>().alpha = 0;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = false;
       //tutorial.GetComponent<CanvasGroup>().interactable = false;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 0;
        //gameOverscreen.GetComponent<CanvasGroup>().interactable = false;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
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
    }

    public void GameOver()
    {
        print("game over");
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 0;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 1;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameOverscore.text = "Sheesh Points: " + score.ToString();
    }

        public IEnumerator ballRespawnTimer()
        {            
           while(ballRespawntimer > 0)
            {
                yield return new WaitForSeconds(ballRespawntimer); 
                ballRespawntimer--;
            }
            ballRespawntimer = 0;
            ball.transform.position = ballRespawn.transform.position;
            ball.GetComponent<SphereCollider>().material.bounciness = ballBounciness;
            print("respawn");
    }

//Menu Stuff
    public void StartGame()
    {
        gameStart = true;
        startMenu.GetComponent<CanvasGroup>().alpha = 0;    
        startMenu.GetComponent<CanvasGroup>().interactable = false;            
        startMenu.GetComponent<CanvasGroup>().interactable = false;       
        GameUI.GetComponent<CanvasGroup>().alpha = 1;     
   }

    public void Tutorial()
    {
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        tutorial.GetComponent<CanvasGroup>().alpha = 1;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameUI.GetComponent<CanvasGroup>().alpha = 0;
        GameUI.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameOver = false;
    }

    public void CloseTutorial()
    {
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        tutorial.GetComponent<CanvasGroup>().alpha = 0;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void Credits()
    {
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        credits.GetComponent<CanvasGroup>().alpha = 1;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void CloseCredits()
    {
        credits.GetComponent<CanvasGroup>().alpha = 0;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void ReplayGame()
    {
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 0;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameUI.GetComponent<CanvasGroup>().alpha = 1;
        GameUI.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameOver = false;
        lives = 3;
        score = 0;
        ball.transform.position = ballRespawn.transform.position;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // GameOver

    public void ReturntoMenu()
    {
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 0;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 0; 
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = true; 
    }

}
