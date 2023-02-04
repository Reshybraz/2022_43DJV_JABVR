using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockpit : MonoBehaviour
{
    private HingeJoint h;
    // Start is called before the first frame update
    void Start()
    {
         h = GetComponent<HingeJoint>();
    }

    public void setAnchor() {
        h.autoConfigureConnectedAnchor = false;
        h.autoConfigureConnectedAnchor = true;
    }

    public float getAngle()
    {
        return h.angle;
    }
}
