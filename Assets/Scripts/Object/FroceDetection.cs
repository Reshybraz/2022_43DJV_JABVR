using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FroceDetection : MonoBehaviour
{

    private Rigidbody RB;
    //private bool simulated;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }



    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Boulet"))
        {
            Debug.Log("rentré");
            this.gameObject.tag = "Simulated";
        }
        
        if (other.relativeVelocity.magnitude > 4f && (other.gameObject.CompareTag("Simulated")) )
        {
            Debug.Log("Hit");
            this.gameObject.tag = "Simulated";
            RB.useGravity = true;
            RB.constraints = RigidbodyConstraints.None;
            RB.drag = 0;
            RB.AddForce(other.relativeVelocity*0.05f,ForceMode.Impulse);
            RB.AddExplosionForce(10f,this.transform.position,1f);
        }
       
    }
}
