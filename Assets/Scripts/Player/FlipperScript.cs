using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition;
    public float hitForce;
    public float flipperDamper = 150f;
    HingeJoint hinge;
    public JointSpring spring;

    public bool IsrightFlipper = false;
    
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
        GetComponent<Rigidbody>().maxAngularVelocity = 99;
    }

    // Update is called once per frame
    void Update()
    {
        spring = new JointSpring();
        spring.spring = hitForce;
        spring.damper = flipperDamper;
        hinge.spring = spring;
        hinge.useLimits = true;
        
      /*if(Input.GetKey(KeyCode.R))
      {
        GetComponent<Rigidbody>().AddTorque(0, 50000000 * hitForce, 0);  
      }

      else
      {
        GetComponent<FlipperScript>().spring.targetPosition = restPosition;
      }*/
    }

    public void FlipperPressed(bool isPressingLeft)
    {
        if(isPressingLeft == IsrightFlipper)
        {
            return;
        }
       gameObject.GetComponent<Rigidbody>().AddTorque(0, 50000000 * hitForce, 0);
       //flipper.GetComponent<FlipperScript>().spring.targetPosition = pressedPosition;      
    }

    public void FlipperReleased(bool isPressingLeft)
    {
        if(isPressingLeft == IsrightFlipper)
        {
            return;
        }
        gameObject.GetComponent<FlipperScript>().spring.targetPosition = restPosition;
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        //print(flipper + "released");
    }
}
