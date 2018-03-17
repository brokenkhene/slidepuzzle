using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	void Start ()
    {
        float screenRatio = (float)Screen.height / (float)Screen.width;
        float _100pxFitCameraSize = screenRatio / 2;
        float _164pxFitCameraSize = _100pxFitCameraSize * 164 / 100;
        Camera.main.orthographicSize = _164pxFitCameraSize;
    }
	
	void Update ()
    {
		
	}
}
