using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{
    private PlayerInput playerInput;
    public FlipperScript flipperscriptRight;
    public FlipperScript flipperScriptLeft;
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
        if(playerInput_.Player.FlipperRight.triggered)
        {
            flipperscriptRight.FlipperPressed(rightFlipper);
        }

        else
        {
            flipperscriptRight.FlipperReleased(rightFlipper);
        }

         if(playerInput_.Player.FlipperLeft.triggered)
        {
            flipperscriptRight.FlipperPressed(leftFlipper);
        }

        else
        {
            flipperscriptRight.FlipperReleased(leftFlipper);
        }


        //right flipper
      if(flipperHeldRight)
      {
          flipperscriptRight.hitForce = 1;
          flipperscriptRight.FlipperPressed(rightFlipper);
      }
      else
      {
            flipperscriptRight.FlipperReleased(rightFlipper);
      }

    //left flipper
      if(flipperHeldLeft)
      {
          flipperScriptLeft.hitForce = -1;
          flipperScriptLeft.FlipperPressed(leftFlipper);
      }

      else
      {
          flipperScriptLeft.FlipperReleased(leftFlipper);
      }
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
        /*if (context.performed)
        { 
            flipperscriptRight.FlipperPressed(rightFlipper);
        }  

        else if(context.canceled)
        {
            flipperscriptRight.FlipperReleased(rightFlipper);
        }   */      
    }
    public void OnFlipperLeft(InputAction.CallbackContext context) //use Left Flipper need to hold
    {
       /* if (context.performed)
        {
            flipperScriptLeft.FlipperPressed(leftFlipper);           
        }   

        else if(context.canceled)
        {
            flipperScriptLeft.FlipperReleased(leftFlipper);
        }*/
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

    private void FlipRight()
    {
        flipperHeldRight = true;
    }

    private void FlipRightReleased()
    {
        flipperHeldRight = false;
    }

    private void FlipLeft()
    {
        flipperHeldLeft = true;
    }

    private void FlipLeftReleased()
    {
        flipperHeldLeft = false;
    }
}