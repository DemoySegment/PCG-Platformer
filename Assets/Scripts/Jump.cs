using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{

    public bool isJumpable =false;
   
    bool playerOnPlatform;
    public GameObject player;

    public GridGenerator generator;
    // Start is called before the first frame update
    void Start()
    {
        generator= GameObject.FindGameObjectWithTag("Floor").GetComponentInParent<GridGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isJumpable ==true && Input.GetKey(KeyCode.Space)){
            if (playerOnPlatform == true)
            {

/*                Debug.Log("Activating thurst");
*/                player.GetComponent<PlayerController>().isHover = true;
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

        generator.removeBlock = gameObject;

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
