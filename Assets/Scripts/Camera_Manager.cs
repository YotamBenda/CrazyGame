using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Manager : MonoBehaviour
{

    [Header("Camera Attributes")]
    public Camera cam;
    [SerializeField] private GameObject[] camPresets;
    

    private void Start()
    {
        cam = Camera.main;
    }

    #region Debugging options
    public void CameraSet(int preset)
    {
        cam = Camera.main;
        cam.gameObject.SetActive(false);
        switch (preset)
        {
            case 0:
                camPresets[preset].gameObject.SetActive(true);
                cam = Camera.main;
                break;

            case 1:
                camPresets[preset].gameObject.SetActive(true);
                cam = Camera.main;
                break;

            case 2:
                camPresets[preset].gameObject.SetActive(true);
                cam = Camera.main;
                break;
        }
    }

    public void FieldOfView (float view)
    {
        cam.fieldOfView = view;
    }

    #endregion
}
