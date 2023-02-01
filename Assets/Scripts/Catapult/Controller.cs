using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float rotation;
    public GameObject boulet;
    public GameObject bouletPlaceholder;
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
        Vector3 height = Vector3.up*input2.getAngle() /(180*20);
        if (Input.GetButtonDown("Jump"))
        {
            GameObject go = Instantiate(boulet, pos.transform.position+height, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            
            Vector3 orientation = transform.forward + transform.up; 
            
            rb.useGravity = true;
            rb.AddForce(orientation* force,ForceMode.Impulse );
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
            bouletPlaceholder.SetActive(false);
        }
        
    }
}
