using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool targetDestroyed;
     GameObject score;
    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward, 50 * Time.deltaTime);
        if(score != null)
        {
            score.GetComponent<TextMeshProUGUI>().SetText(PublicVars.score.ToString());

        }
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
