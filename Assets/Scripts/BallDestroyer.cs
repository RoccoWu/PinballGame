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
            gameManager.lives--;
            if(gameManager.lives == 0f)
            {
                gameManager.gameOver = true;
            }
            else
            {
                StartCoroutine(gameManager.ballRespawnTimer(2));
            }
        }
    }
}
