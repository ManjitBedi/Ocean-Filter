using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// This component is attached to the UI document in the scene.
/// </summary>
public class MainMenu : MonoBehaviour
{
    GameObject faceMask;
    GameObject visorGameObject;
    GameObject ovalGameObject;

    private void OnEnable()
    {

    }

    private void Start()
    {
        FindGameObjects();
        ConfigureUI();
    }

    private void FindGameObjects()
    {
        Debug.Log("find game objects");
        visorGameObject = GameObject.Find("visor");
        ovalGameObject = GameObject.Find("ovals");

        if (visorGameObject != null)
        {
            Debug.Log("visor game object configured");
            visorGameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("visor game object not found");
        }

        if (ovalGameObject != null)
        {
            Debug.Log("oval game object configured");
            ovalGameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("oval game object not found");
        }
    }

    private void ConfigureUI()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        VisualElement container1 = root.Q<VisualElement>("container-particles");
        VisualElement container2 = root.Q<VisualElement>("container-face");

        //  Get references to the buttons in the menu document.
        Button particleFX1Button = container1.Q<Button>("FX1");
        Button particleFX2Button = container1.Q<Button>("FX2");
        Button particleFX3Button = container1.Q<Button>("FX3");

        Button visorButton = container2.Q<Button>("visor");
        Button ovalButton = container2.Q<Button>("oval");
        Button noneButton = container2.Q<Button>("none");

        Button resetButton = root.Q<VisualElement>("container-bottom").Q<Button>("reset");

        particleFX1Button.clicked += () => Debug.Log("FX 1");
        particleFX2Button.clicked += () => Debug.Log("FX 2");
        particleFX3Button.clicked += () => Debug.Log("FX 3");

        visorButton.clicked += () =>
        {
            Debug.Log("display visor game object");
            visorGameObject?.SetActive(true);
            ovalGameObject?.SetActive(false);
        };

        ovalButton.clicked += () =>
        {
            Debug.Log("display oval game object");
            visorGameObject?.SetActive(false);
            ovalGameObject?.SetActive(true);
        };

        noneButton.clicked += () =>
        {
            Debug.Log("display 'no' game object");
            visorGameObject?.SetActive(false);
            ovalGameObject?.SetActive(false);
        };

        resetButton.clicked += () => FindGameObjects();
    }
}
