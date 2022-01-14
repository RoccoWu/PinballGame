using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    [Header("Launcher")]
    public float launchPower;
    public float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;
    // Start is called before the first frame update
    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
    }

    // Update is called once per frame
    void Update()
    {
         powerSlider.value = launchPower; 
    }
     private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("ball"))
        {
            ballList.Add(col.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider col)
    {
         ballList.Remove(col.gameObject.GetComponent<Rigidbody>());
         launchPower = 0f;
    }
}
