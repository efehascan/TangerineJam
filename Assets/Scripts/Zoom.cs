using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] public bool zoomActive;
    
    private Vector3[] Target;
    
    public Camera cam;
    
    public float zoomSpeed;

    void CamZoom()
    {
        if (zoomActive)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, zoomSpeed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, zoomSpeed);
        }
    }
    
    
}
