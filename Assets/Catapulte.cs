using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Catapulte : MonoBehaviour
{
    private float strartSpring;
    private HingeJoint h;
    private XRGrabInteractable xr;
    private bool isarming;
    // Start is called before the first frame update
    void Start()
    {
        isarming = true;
        h = GetComponent<HingeJoint>();
        xr = GetComponent<XRGrabInteractable>();
        strartSpring = h.spring.spring;
    }

    public float getAngle()
    {
        return h.angle;
    }
    public bool getArming() {
        return isarming;
    }

    // Update is called once per frame
    void Update()
    {
        if (h.angle > 95) {
            isarming = false;
        }
    }

    public void launch() {
        isarming=true;
    }
}