using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectController : MonoBehaviour
{
    private static int _headJointIndex = (int)KinectWrapper.NuiSkeletonPositionIndex.Head;
    private static Vector3 _defaultHeadPosition = new Vector3(0f, 0f, 0f);
    private static Vector3 _positionTransform = new Vector3(1f, 1f, -1f);

    public GameObject target;

    private Vector3 _headPosition;

    public Vector3 HeadPosition
    {
        get { return _headPosition; }
    }

    void Start () {
        target.transform.position = _defaultHeadPosition;
    }
	
	void Update ()
    {
        var newPosition = _GetNewHeadPosition();
        if (newPosition != Vector3.zero)
        {
            target.transform.position = newPosition * 10f;
        }
    }

    private Vector3 _GetNewHeadPosition()
    {
        KinectManager manager = KinectManager.Instance;
        if (manager && manager.IsInitialized() && manager.IsUserDetected())
        {
            uint userId = manager.GetPlayer1ID();
            if (manager.IsJointTracked(userId, _headJointIndex))
            {
                var newPosition = manager.GetRawSkeletonJointPos(userId, _headJointIndex);
                newPosition.Scale(_positionTransform);
                return newPosition;
            }
        }
        return _defaultHeadPosition;
    }
}
