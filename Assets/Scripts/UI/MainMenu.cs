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
    [SerializeField]
    AppState appState;

    private void OnEnable()
    {

    }

    private void Start()
    {
        ConfigureUI();
    }

    /// <summary>
    /// Configure the buttons with actions to change the 3D objects in thes scene
    /// and select a particle effect using the visual effects graph.
    /// </summary>
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

        particleFX1Button.clicked += () => appState.SelectVisualEffect(0);
        particleFX2Button.clicked += () => appState.SelectVisualEffect(1);
        particleFX3Button.clicked += () => appState.SelectVisualEffect(2);

        visorButton.clicked += () =>
        {
            Debug.Log("display visor game object");
            appState.FaceAccessoryIndex = 1;
        };

        ovalButton.clicked += () =>
        {
            Debug.Log("display oval game object");
            appState.FaceAccessoryIndex = 2;
        };

        noneButton.clicked += () =>
        {
            Debug.Log("display 'no' game object");
            appState.FaceAccessoryIndex = 0;
        };
    }
}
