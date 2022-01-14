using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitForce = 10000f;
    public float fliopperDamper = 150f;
    HingeJoint hinge;
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
        spring.damper = fliopperDamper;
        
        if(Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().AddTorque(0, 50000000 * hitForce, 0);
            print("adding force");
        }

        else
        {
            spring.targetPosition = restPosition;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
