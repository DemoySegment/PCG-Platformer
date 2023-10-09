using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{
    public bool gameOverTrigger;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameOverTrigger)
            {
                Debug.Log("Game Over");

            }
        }
    }
}
