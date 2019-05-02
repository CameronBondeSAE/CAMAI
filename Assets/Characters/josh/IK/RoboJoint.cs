using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoboJoint : MonoBehaviour
{
    
    public bool test;
    public bool test2;
    public bool test3;
    public bool test4;
    public List<IKJoint> Joints;

    public float SamplingDistance;
    public float LearningRate;

    public GameObject target;

    private void Awake()
    {
        if (test3)
        {
            foreach (IKJoint item in Joints)
            {
                item.transform.SetParent(null);
            }
        }
    }

    private void Update()
    {
        if (test)
        {
            //Debug.Log(ForwardKinematics());
            Joints[3].transform.LookAt(target.transform);
            test = false;
        }

        if (test2)
        {
            InverseKinematics(target.transform.position);
        }

        if (test3)
        {
            drag(target.transform.position, false);
            if (test4) drag(Vector3.zero, true);
        }

        if (test4 && !test3)
        {
        }
    }

    public Vector3 ForwardKinematics()
    {
        Vector3 prevPoint = Joints[0].transform.position;
        Quaternion rotation = Quaternion.identity;
        for (int i = 1; i < Joints.Count; i++)
        {
            // Rotates around a new axis
            rotation *= Quaternion.AngleAxis(Joints[i - 1].angle, Joints[i - 1].Axis);
            Vector3 nextPoint = prevPoint + rotation * Joints[i].gameObject.transform.localPosition;
    
            prevPoint = nextPoint;
        }
        return prevPoint;
    }
    public float DistanceFromTarget(Vector3 target)
    {
        Vector3 point = ForwardKinematics();
        return Vector3.Distance(point, target);
    }
    public float PartialGradient (Vector3 target, int i)
    {
        // Saves the angle,
        // it will be restored later
        float angle = Joints[i].angle;

        // Gradient : [F(x+SamplingDistance) - F(x)] / h
        float f_x = DistanceFromTarget(target);

        Joints[i].SetAngles(Joints[i].angle + SamplingDistance);
        float f_x_plus_d = DistanceFromTarget(target);

        float gradient = (f_x_plus_d - f_x) / SamplingDistance;

        // Restores
        Joints[i].SetAngles(angle);

        return gradient;
    }
    public void InverseKinematics (Vector3 target)
    {
        if (DistanceFromTarget(target) < 0.1f)
            return;
        for (int i = 0; i < Joints.Count; i ++)
        {
            // Gradient descent
            // Update : Solution -= LearningRate * Gradient
            float gradient = PartialGradient(target, i);
            float temp = Joints[i].angle - gradient*DistanceFromTarget(target)*LearningRate;
 
            // Clamp
            Joints[i].SetAngles(temp);
            Debug.Log("test");
            
            // Early termination
            if (DistanceFromTarget(target) < 0.1f)
                return;
        }
    }

    public Quaternion subdrag(Quaternion Rot, Vector3 pos, Vector3 end)
    {
        Quaternion temp = Rot;
        Vector3 temp2 = new Vector3();
        float temp3 = 0;
        temp.ToAngleAxis(out temp3,out temp2);
        temp *= Quaternion.FromToRotation(temp2, (end - pos).normalized);
        return temp;
    }

    public void drag(Vector3 end, bool back)
    {
        Vector3 temppos = end;
        for (int i = 0; i < Joints.Count; i++)
        {
            if (back)
            {
                // look at new position
                Joints[(Joints.Count-1)-i].transform.LookAt(temppos);
                // move to new position
                Joints[(Joints.Count-1)-i].transform.position = temppos - Joints[(Joints.Count-1)-i].transform.forward;
                temppos = Joints[(Joints.Count-1)-i].transform.position;
            }
            else
            {
                // look at new position
                Joints[i].transform.LookAt(temppos);
                // move to new position
                Joints[i].transform.position = temppos - Joints[i].transform.forward;
                temppos = Joints[i].transform.position;
            }
        }
    }
    
}
