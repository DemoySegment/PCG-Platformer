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

        UnityEngine.UIElements.Button start = root.Q<UnityEngine.UIElements.Button>("Start");
        UnityEngine.UIElements.Button exit = root.Q<UnityEngine.UIElements.Button>("Exit");

        start.clicked += () => SceneManager.LoadScene("Main");
        exit.clicked += () => Application.Quit();
    }
}
