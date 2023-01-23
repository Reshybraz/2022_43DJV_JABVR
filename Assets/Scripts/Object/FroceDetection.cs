using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FroceDetection : MonoBehaviour
{

   private float timer = 5f;
   private Rigidbody RB;

   private void Start()
   {
       RB = GetComponent<Rigidbody>();
       RB.AddExplosionForce(50f, transform.parent.position, 5.0f, 3.0F,ForceMode.Impulse);
   }

   // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }




}
