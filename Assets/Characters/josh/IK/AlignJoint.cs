using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignJoint : MonoBehaviour
{
    public bool worldspace = true;
    public List<IKJoint> Joints;
    public GameObject target;

    private Quaternion offset = Quaternion.AngleAxis(90,new Vector3(0,1,0));

    public bool side = false;
    // Start is called before the first frame update
    void Start()
    {
        //if (worldspace)
        {
            List<IKJoint> temp = new List<IKJoint>();
            //temp.Add(Joints[0]);
            foreach (IKJoint item in Joints[0].transform.GetComponentsInChildren<IKJoint>())
            {
                temp.Add(item);
            }

            Joints = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (worldspace)
        {
            drag2(target.transform.position, target.transform.rotation);
        }
        else
        {
            if (side)
            {
                drag3(target.transform.position, target.transform.rotation*offset);
            }
            else
            {
                drag3(target.transform.position, target.transform.rotation);
            }
        }
    }
    public void drag2(Vector3 end,Quaternion test)
    {
        // save old position
        List<Vector3> temppos = new List<Vector3>();
        foreach (IKJoint item in Joints)
        {
            temppos.Add(item.transform.position);
        }
        // move all to new position
        Joints[0].transform.position = end;
        Joints[0].transform.rotation = test;
        
        for (int i = 1; i < Joints.Count; i++)
        {
            // look at old position
            if (i != Joints.Count - 1)
            {
                Joints[i].transform.LookAt(temppos[i+1]);
                Joints[i].transform.rotation = Quaternion.Slerp(Joints[i].transform.rotation,Joints[i-1].transform.rotation,0.5f);
            }
        }
    }
    public void drag3(Vector3 end,Quaternion test)
    {
        // save old position
        List<Vector3> temppos = new List<Vector3>();
        foreach (IKJoint item in Joints)
        {
            temppos.Add(item.transform.position);
        }
        // move all to new position
        Joints[0].transform.position = end;
        Joints[0].transform.rotation = test;
        
        for (int i = 1; i < Joints.Count; i++)
        {
            // look at old position
            if (i != Joints.Count - 1)
            {
                Joints[i].transform.LookAt(temppos[i+1]);
                Joints[i].transform.rotation = Quaternion.Slerp(Joints[i].transform.rotation,Joints[i-1].transform.rotation,0.1f);
            }
        }
    }
}
