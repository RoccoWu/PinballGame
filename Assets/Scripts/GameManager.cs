using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
}
