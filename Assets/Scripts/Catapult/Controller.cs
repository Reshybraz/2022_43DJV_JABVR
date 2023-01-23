using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float rotation;
    public GameObject boulet;
    public Transform pos;
    public Cockpit input;
    public Cockpit input2;
    public Catapulte manivelle;
    
    public float force;
    // Update is called once per frame
    void Update()
    {


        float rot =  Input.GetAxisRaw("Horizontal");

        transform.Rotate(Vector3.up, input.getAngle() / 90.0f);
        transform.Translate(Vector3.up*input2.getAngle() /(90.0f*50));
        if (transform.position.y >10 ) {
            new Vector3 (transform.position.x,50,transform.position.z);
        }
        if (transform.position.y <0 ) {
            transform.position = new Vector3 (transform.position.x,0,transform.position.z);
        }
        
    
    }

    public void launchBall()
    {

        if (!manivelle.getArming()) {
            GameObject go = Instantiate(boulet, pos.transform.position, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            
            Vector3 orientation = transform.forward + transform.up; 
            
            rb.useGravity = true;
            rb.AddForce(orientation* (force*manivelle.getCharge()),ForceMode.Impulse );
        }
        
    }
}
