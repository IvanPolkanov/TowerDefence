using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContainer : MonoBehaviour
{
    public static Transform currentCamera;

    private void Start()
    {
        AddCurrentCamera();    
    }

    private void AddCurrentCamera()
    {
        currentCamera = transform;
    }
}
