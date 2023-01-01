using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DebugForce : MonoBehaviour
{
    public Rigidbody rb;
    
    public Transform direction;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce( (direction.position - this.transform.position).normalized * 5000f,ForceMode.Impulse );
        }
    }
}
