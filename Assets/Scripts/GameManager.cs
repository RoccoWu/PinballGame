using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject startMenu;
    public Button startButton;
    public Button tutorialButton;
    public Button quitButton;    

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

    public void StartGame()
    {
        gameStart = true;
        startMenu.GetComponent<CanvasGroup>().alpha = 0;               
    }

    public void Tutorial()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
