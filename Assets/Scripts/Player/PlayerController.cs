using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{
    private PlayerInput playerInput;
    private FlipperScript flipperscript;
    public GameObject rightFlipper;
    public GameObject leftFlipper;

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
        flipperscript = FindObjectOfType<FlipperScript>();
        rightFlipper = GameObject.FindGameObjectWithTag("rightFlipper");
        leftFlipper = GameObject.FindGameObjectWithTag("leftFlipper");        
    }

    // Update is called once per frame
    void Update()
    {
      
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

    public void OnFlipperRight(InputAction.CallbackContext context) //use Right Flipper
    {
        if (context.phase != InputActionPhase.Canceled)
        { 
             flipperscript.hitForce = 1;
            flipperscript.FlipperPressed(rightFlipper);
        }  

        else
        {
            flipperscript.FlipperReleased(rightFlipper);
        }         
    }
    public void OnFlipperLeft(InputAction.CallbackContext context) //use Left Flipper
    {
        if (context.phase != InputActionPhase.Canceled)
        {
            flipperscript.hitForce = -1;
            flipperscript.FlipperPressed(leftFlipper);
        }   

        else
        {
            flipperscript.FlipperReleased(leftFlipper);
        }
    }

    public void OnBallLauncher(InputAction.CallbackContext context)
    {
          if (context.phase != InputActionPhase.Canceled)
        {
            print("launch ball");  
        }  
    }   
}