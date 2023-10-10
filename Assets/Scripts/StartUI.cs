using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartUI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button start = root.Q<Button>("Start");
        Button exit = root.Q<Button>("Exit");

        start.clicked += () => SceneManager.LoadScene("Main");
        exit.clicked += () => Application.Quit();
    }
}
