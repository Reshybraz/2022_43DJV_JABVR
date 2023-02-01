using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelfDestruction : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(SelfDestruct());
     }
     IEnumerator SelfDestruct()
     {
         yield return new WaitForSeconds(20f);
         Destroy(gameObject);
     }
}
