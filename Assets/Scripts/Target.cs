using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bullet")){
            Destroy(other.gameObject);
            PublicVars.score += 5;
            print(PublicVars.score);
            Destroy(gameObject);
            }
        
    }

}
