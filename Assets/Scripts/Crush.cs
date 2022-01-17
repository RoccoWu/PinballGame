using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip hitAudio;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("ball"))
        {
            gameManager.score -= 500;
            audioSource.PlayOneShot(hitAudio, 0.69f);
        }
    }
}
