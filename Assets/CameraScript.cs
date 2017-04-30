using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinectBox.Global;

public class CameraScript : MonoBehaviour
{
    private Camera _cam;

    void Start ()
    {
        _cam = gameObject.GetComponent<Camera>();
    }
	
	void LateUpdate ()
    {
        _cam.transform.position = GameController.Instance.HeadPosition;
    }
}
