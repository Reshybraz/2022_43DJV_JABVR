using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SelfDestruction : MonoBehaviour
{
    private Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        
        RB.AddExplosionForce(50f, transform.parent.position, 5.0f, 3.0F,ForceMode.Impulse);
         StartCoroutine(SelfDestruct());
     }
     IEnumerator SelfDestruct()
     {
         yield return new WaitForSeconds(10f);
         Destroy(gameObject);
     }
}
