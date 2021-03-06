using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScriptLeft : MonoBehaviour
{
     public float restPosition = 0f;
    public float pressedPosition;
    public float hitForce;
    public float flipperDamper = 150f;
    HingeJoint hinge;
    public JointSpring spring;
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
    }

    public void FlipperPressed(GameObject flipper)
    {
       flipper.GetComponent<Rigidbody>().AddTorque(0, 50000000 * hitForce, 0);
       //flipper.GetComponent<FlipperScript>().spring.targetPosition = pressedPosition;
       //print(flipper + "pressed");
    }

    public void FlipperReleased(GameObject flipper)
    {
        flipper.GetComponent<FlipperScript>().spring.targetPosition = restPosition;
        flipper.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
        //print(flipper + "released");
    }
}
