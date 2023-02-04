using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Catapulte : MonoBehaviour
{
    public GameObject bouletPlaceholder;
    private float strartSpring;
    private HingeJoint h;
    private XRGrabInteractable xr;
    private bool isarming;
    [SerializeField]
    private float launchAngle;
    // Start is called before the first frame update
    void Start()
    {
        isarming = true;
        h = GetComponent<HingeJoint>();
        xr = GetComponent<XRGrabInteractable>();
        strartSpring = h.spring.spring;
    }

    public void setAnchor() {
        h.autoConfigureConnectedAnchor = false;
        h.autoConfigureConnectedAnchor = true;
    }

    public float getAngle()
    {
        return h.angle;
    }
    public bool getArming() {
        return isarming;
    }

    public void launch() {
        isarming=true;
    }

    public void setCharge() {
        isarming = false;
        launchAngle = h.angle;
        bouletPlaceholder.SetActive(true);
    }

    public float getCharge() {
        return launchAngle/100;
    }
}
