using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using System;
using UnityEngine.XR.ARFoundation;

public class AppState : MonoBehaviour
{

	/// <summary>
	/// Set to 0 to not display any accessories on the face mesh.
	/// </summary>
	///
	private int _faceAccessoryIndex = 1;

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
            faceMeshGameObject = arFace.gameObject;
			visorGameObject = GameObject.FindGameObjectWithTag("visor");
            ovalsGameObject = GameObject.FindGameObjectWithTag("ovals");
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
}

