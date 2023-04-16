using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using System;
using UnityEngine.XR.ARFoundation;

public class AppState : MonoBehaviour
{
	[SerializeField]
	GameObject visualEffect1;

    [SerializeField]
    GameObject visualEffect2;

    [SerializeField]
    GameObject visualEffect3;


    /// <summary>
    /// Set to 0 to not display any accessories on the face mesh.
    /// </summary>
    ///
    private int _faceAccessoryIndex = 1;

    /// <summary>
	/// Display an accessory over the face mesh.
    /// <list type="list">
    ///	<item> 0 - none</item>
    ///	<item> 1 - visor</item>
    ///	<item> 2 - ovals</item>
    /// </list>
    /// </summary>
    public int FaceAccessoryIndex
	{
		get => _faceAccessoryIndex;
		set
		{
            _faceAccessoryIndex = value;
			SettingsChanged();
        }
	}


	/// <summary>
	/// 
	/// </summary>
	public int fishFx = 0;

	[SerializeField]
    UnityEngine.XR.ARFoundation.ARFaceManager faceManager;

	private GameObject faceMeshGameObject;

	private GameObject visorGameObject;

	private GameObject ovalsGameObject;

	void OnEnable()
	{
        faceManager.facesChanged += FacesChanged;

    }

    void OnDisable()
    {
        faceManager.facesChanged -= FacesChanged;
    }

    /// <summary>
    /// Handle when a faces changed event occurs
    /// </summary>
    /// <param name="facesChanged"></param>
    void FacesChanged(ARFacesChangedEventArgs facesChangedArgs)
    {
		if (facesChangedArgs.added.Count > 0)
		{
            Debug.Log("face changed event: face detected");
			UpdateFaceMesh(facesChangedArgs.added[0]);
        }
    }


	/// <summary>
	/// Set the accesories displayed on the face mesh according to the app state
	/// </summary>
	private void UpdateFaceMesh(ARFace arFace)
	{
		if (faceMeshGameObject == null)
		{
			Debug.Log("get references to game objects on the AR Face");
            faceMeshGameObject = arFace.gameObject;
			visorGameObject = GameObject.FindGameObjectWithTag("visor");
            ovalsGameObject = GameObject.FindGameObjectWithTag("ovals");

			Debug.Log($"game objects {(faceMeshGameObject != null ? 1 : 0)}, {(visorGameObject != null ? 1 : 0)}, {(ovalsGameObject != null ? 1 : 0)}");
			if (faceMeshGameObject != null)
			{
                Debug.Log($"number of child objects on AR game object {arFace.transform.childCount}");
                Transform[] allChildren = faceMeshGameObject.GetComponentsInChildren<Transform>();
                foreach(Transform t in allChildren)
				{
					Debug.Log($"child game object {t.gameObject.name}, tag {t.gameObject.tag}");
				}
            }
        }

        SettingsChanged();
    }

	/// <summary>
	/// Handle when a setting has changed to update the accessories displayed with the face mesh.
	/// </summary>
	public void SettingsChanged()
	{
		switch (_faceAccessoryIndex)
		{
			case 1:
                visorGameObject.SetActive(true);
                ovalsGameObject.SetActive(false);
                break;

            case 2:
                visorGameObject.SetActive(false);
                ovalsGameObject.SetActive(true);
                break;

			default:
				visorGameObject.SetActive(false);
				ovalsGameObject.SetActive(false);
				break;
        }
    }

    public void SelectVisualEffect(int index)
    {
        switch (index)
        {
            case 0:
                visualEffect1.SetActive(true);
                visualEffect2.SetActive(false);
                visualEffect3.SetActive(false);
                break;

            case 1:
                visualEffect1.SetActive(false);
                visualEffect2.SetActive(true);
                visualEffect3.SetActive(false);
                break;

            case 2:
                visualEffect1.SetActive(false);
                visualEffect2.SetActive(false);
                visualEffect3.SetActive(true);
                break;
        }
    }
}

