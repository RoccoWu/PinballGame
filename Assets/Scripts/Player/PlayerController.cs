using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{
    private PlayerInput playerInput;
    public FlipperScript flipperscriptRight;
    public FlipperScript flipperscriptLeft;
    private BallLauncher balllauncherScript;
    public GameObject rightFlipper;
    public GameObject leftFlipper;
    public GameObject ballLauncher;
    public Action OnHoldFlipper;
    public bool flipperHeldRight = false;
    public bool flipperHeldLeft = false;

    private PlayerInput playerInput_
    {
        get  
        {
            playerInput ??= new PlayerInput(); //creates new playerInput when the player input is null
            return playerInput;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        balllauncherScript = FindObjectOfType<BallLauncher>();          
        ballLauncher = GameObject.FindGameObjectWithTag("balllauncher");  
    }

    // Update is called once per frame
    void Update()
    {
        //right flipper
      if(flipperHeldRight)
      {
          flipperscriptRight.hitForce = 1;
          flipperscriptRight.FlipperPressed(false);
      }
      else
      {
            flipperscriptRight.FlipperReleased(true);
      }

        //left flipper
      if(flipperHeldLeft)
      {
          flipperscriptLeft.hitForce = -1;
          flipperscriptLeft.FlipperPressed(true);
      }

      else
      {
          flipperscriptLeft.FlipperReleased(false);
      }
      print(flipperscriptRight);

    }
     private void OnEnable()
    {
        playerInput_.Enable();
        playerInput_.Player.SetCallbacks(this);
    }
    private void OnDisable()
    {
        playerInput_.Disable();       
    }

    public void OnFlipperRight(InputAction.CallbackContext context) //use Right Flipper need to hold
    {
        if (context.performed)
        { 
            flipperHeldRight = true;
        }  

        else if(context.canceled)
        {
            flipperHeldRight = false;
        }         
    }
    public void OnFlipperLeft(InputAction.CallbackContext context) //use Left Flipper need to hold
    {
        if (context.performed)
        {
            flipperHeldLeft = true;           
        }   

        else if(context.canceled)
        {
            flipperHeldLeft= false;
        }
    }

    public void OnBallLauncher(InputAction.CallbackContext context)
    {
          if (context.phase != InputActionPhase.Canceled)
        {              
            balllauncherScript.launchCharging = true;  
            print("CHARGE BALL");        
        }  

        else
        {            
            balllauncherScript.launchCharging = false;
            print("RELEASE BALL");
        }
    }   
}