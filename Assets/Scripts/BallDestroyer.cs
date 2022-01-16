using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    public GameManager gameManager;
   // public GameObject respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("ball"))
        {
            gameManager.ballRespawntimer = 2f;
            print(gameManager.ballRespawntimer);
            gameManager.lives--;
            if(gameManager.lives == 0f)
            {
                gameManager.gameOver = true;
                 gameManager.GameOver();
            }
            else
            {
                RespawnBall();
                print("starting timer");
            }
        }
    }

    private void RespawnBall()
    {
        StartCoroutine(gameManager.ballRespawnTimer());
        gameManager.ballRespawntimer = 2f;
    }
}
