using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Button : MonoBehaviour
{
    public Text scoreText;
    void Start(){
        scoreText.text = "Score: " + PublicVars.score.ToString();
    }

    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene("Main");
    }
}
