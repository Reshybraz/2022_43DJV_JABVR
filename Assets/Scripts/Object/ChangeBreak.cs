using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ChangeBreak : MonoBehaviour
{
    public GameObject BasicMesh;
    public Party party;
    private BoxCollider col;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boulet"))
        {
            col.enabled = false;
            Instantiate(BasicMesh, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            party.nbDestroy++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
   
        col = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
