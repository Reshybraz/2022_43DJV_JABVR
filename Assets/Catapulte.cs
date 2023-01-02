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

    // Update is called once per frame
    void Update()
    {
        if (isarming) {
            if (!h.useSpring) {
                xr.enabled=true;
                h.useSpring=true;
            }
            
            if (h.angle > 175) {
                isarming = false;
            }
        }
        else {
            if (h.angle <= 175) {
                isarming=true;
            }
            xr.enabled = false;
            h.useSpring = false;
        }
    }

    public void launch() {
        isarming=true;
    }
}
