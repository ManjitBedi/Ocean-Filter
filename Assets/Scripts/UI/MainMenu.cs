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
    private void OnEnable()
    {
        ConfigureUI();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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

        particleFX1Button.clicked += () => Debug.Log("FX 1");
        particleFX2Button.clicked += () => Debug.Log("FX 2");
        particleFX3Button.clicked += () => Debug.Log("FX 3");

        visorButton.clicked += () => Debug.Log("visor");
        ovalButton.clicked += () => Debug.Log("oval");
        noneButton.clicked += () => Debug.Log("none");
    }
}
