using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKJoint : MonoBehaviour
{
    public Vector3 axis;

    public Vector3 Axis
    {
        get { return axis; }
        set
        {
            axis = value;
        }
    }

    public float Angle;

    public float angle
    {
        get { return Angle; }
        set
        {
            Angle = Mathf.Clamp(value, MinAngle, MaxAngle);
        }
    }

    public float MinAngle;
    public float MaxAngle;
    // Update is called once per frame
    public void SetAngles(float ang)
    {
        angle = ang;
        gameObject.transform.localRotation = Quaternion.AngleAxis(angle,Axis);
    }
}
