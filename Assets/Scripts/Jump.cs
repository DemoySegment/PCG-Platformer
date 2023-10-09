using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{

    public bool isJumpable =false;
   
    bool playerOnPlatform;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isJumpable ==true && Input.GetKey(KeyCode.Space)){
            if (playerOnPlatform == true)
            {

                Debug.Log("Activating thurst");
                player.GetComponent<PlayerController>().isHover = true;
                StartCoroutine(jumpActivate());
            }
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            

               player = collision.gameObject;

            player.GetComponent<PlayerController>().isHover = false;



        }
    }

    private void OnCollisionExit(Collision collision)
    {
        playerOnPlatform = false;
    }

  IEnumerator jumpActivate()
    {
     
    
    yield return new WaitForSeconds(1f);
       
        Destroy(gameObject);
    }

}
