using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    [Header("Launcher")]
    public float launchPower;
    public float powerMultiplier;
    public float minPower = 0f;
    public float maxPower = 100f;
    public Slider powerSlider;
    public List<Rigidbody> ballList;
    public bool ballReady;
    public bool launchCharging = false;
    // Start is called before the first frame update
    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else 
        {
          powerSlider.gameObject.SetActive(false);  
        }   
         powerSlider.value = launchPower;
         if(ballList.Count > 0)
         {
             ballReady = true;
             
             if(launchCharging)
             {
                 if(launchPower <= maxPower)
                 {
                     launchPower += powerMultiplier * Time.deltaTime;
                 }
             }
             else
             {
                 foreach(Rigidbody rb in ballList)
                 {
                     rb.AddForce(launchPower * Vector3.forward, ForceMode.Impulse);
                 }
             }
         }
         else
         {
             ballReady = false;
             launchPower = 0f;
         }
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

    public void BallCharge()
    {
        launchCharging = true;
        print("charging the launch");
    }

    public void BallRelease()
    {
        launchCharging = false;
        print("releasing the launch");
    }
}
