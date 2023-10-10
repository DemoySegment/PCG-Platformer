using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Button : MonoBehaviour
{
    public Text scoreText;
    void Start(){
        Cursor.lockState = CursorLockMode.None;
        scoreText.text = "Score: " + PublicVars.score.ToString();
    }

    public void LoadSceneOnClick()
    {
        PublicVars.score = 0;
        SceneManager.LoadScene("Main");
    }
}
