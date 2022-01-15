using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f; 
    public float hitForce;
    public float flipperDamper = 150f;
    HingeJoint hinge;
    public string inputName;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitForce;
        spring.damper = flipperDamper;
        if(Input.GetAxis(inputName) == 1)
        {
            GetComponent<Rigidbody>().AddTorque(0, 50000000 * hitForce, 0);
        }
        else
        {
            GetComponent<FlipperScript>().spring.targetPosition = restPosition;
        }

        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
