using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public KinectController kinectController;

    private Camera _cam;

    void Start ()
    {
        _cam = gameObject.GetComponent<Camera>();
    }
	
	void Update ()
    {
        _cam.transform.position = kinectController.HeadPosition * 10f;
    }
}
