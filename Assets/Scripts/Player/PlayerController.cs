using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{
    private PlayerInput playerInput;
    private FlipperScript flipperscript;
    private GameObject rightFlipper;
    private GameObject leftFlipper;
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
            print("flipper right");  
            //flipperscript.flipper
        }            
    }
    public void OnFlipperLeft(InputAction.CallbackContext context) //use Left Flipper
    {
        if (context.phase != InputActionPhase.Canceled)
        {
            print("flipper left");  
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