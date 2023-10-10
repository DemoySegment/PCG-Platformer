using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool targetDestroyed;
    private void Update()
    {
        transform.Rotate(Vector3.forward, 50 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bullet")){
            Destroy(other.gameObject);
            PublicVars.score += 5;
            print(PublicVars.score);
            targetDestroyed = true;


            gameObject.SetActive(false);            
        }
        else
        {
            targetDestroyed = false;
        }
        
    }

}
