using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject startMenu;
    public GameObject tutorial;
    public Button startButton;
    public Button tutorialButton;
    public Button closetutorialButton;
    public Button quitButton;   

    [Header("Game Over")]
    public GameObject gameOverscreen; 
    public Button returntoMenu;

    [Header("Core Game Loop")]
    public bool gameStart = false;
    public PlayerController playerController;
    public float lives = 3;
    public bool gameOver = false;
    public GameObject ball;
    public GameObject ballRespawn;
    // Start is called before the first frame update
    void Start()
    {
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        tutorial.GetComponent<CanvasGroup>().alpha = 0;
       //tutorial.GetComponent<CanvasGroup>().interactable = false;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameOverscreen.GetComponent<CanvasGroup>().alpha = 0;
        //gameOverscreen.GetComponent<CanvasGroup>().interactable = false;
        gameOverscreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameOver()
    {
        print("game over");
    }

        public IEnumerator ballRespawnTimer(int seconds)
        {
            int counter = seconds;
           while(counter > 0)
            {
                yield return new WaitForSeconds(2); //wait 2 seconds
                ball.transform.position = ballRespawn.transform.position;
            }
    }

//Menu Stuff
    public void StartGame()
    {
        gameStart = true;
        startMenu.GetComponent<CanvasGroup>().alpha = 0;    
        startMenu.GetComponent<CanvasGroup>().interactable = false;            
    }

    public void Tutorial()
    {
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        tutorial.GetComponent<CanvasGroup>().alpha = 1;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void CloseTutorial()
    {
        tutorial.GetComponent<CanvasGroup>().alpha = 0;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = false;
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        startMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
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
