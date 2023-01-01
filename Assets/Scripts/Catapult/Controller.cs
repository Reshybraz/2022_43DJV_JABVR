using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float rotation;
    public Rigidbody boulet;

    public float force;
    // Update is called once per frame
    void Update()
    {


        float rot =  Input.GetAxisRaw("Horizontal"); 
        
        this.transform.Rotate(this.transform.up * rot *rotation );


        if (Input.GetButtonDown("Jump"))
        {

            Vector3 orientation = transform.forward + transform.up; 
            
            Debug.DrawRay(boulet.transform.position,orientation,Color.red,1000f);
            
           boulet.useGravity = true;
            boulet.AddForce(orientation* force,ForceMode.Impulse );
        }
        
    
    }
}
