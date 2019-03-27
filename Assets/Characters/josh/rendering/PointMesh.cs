using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMesh
{
    public Vector3 origin = Vector3.zero;
    public Quaternion rotation = Quaternion.identity;

    public List<Vector3> Points;

    public float scale = 1;

    public void makecube()
    {
        Points = new List<Vector3>();
        Points.Add(new Vector3(-0.5f,-0.5f,-0.5f));
        Points.Add(new Vector3(-0.5f,-0.5f,0.5f));
        Points.Add(new Vector3(-0.5f,0.5f,-0.5f));
        Points.Add(new Vector3(-0.5f,0.5f,0.5f));
        
        Points.Add(new Vector3(0.5f,-0.5f,-0.5f));
        Points.Add(new Vector3(0.5f,-0.5f,0.5f));
        Points.Add(new Vector3(0.5f,0.5f,-0.5f));
        Points.Add(new Vector3(0.5f,0.5f,0.5f));
        origin = new Vector3(0.5f,0.5f,-8);
    }

    public void rotateobj()
    {
        rotation = rotation * Quaternion.Euler(0.5f,0.2f,0.1f);
        //Debug.Log(rotation.eulerAngles);
    }

    public List<Vector3> worldpos()
    {
        List<Vector3> temp = new List<Vector3>();
        foreach (Vector3 item in Points)
        {
            // y axis
            Vector3 newdir = new Vector3((item.x *Mathf.Cos(Time.time))+(item.z *-Mathf.Sin(Time.time)),item.y,(item.z*Mathf.Cos(Time.time))+(item.x *Mathf.Sin(Time.time)))* scale;

            // z axis
            //Vector3 newdir = new Vector3((item.x *Mathf.Cos(Time.time))+(item.y *-Mathf.Sin(Time.time)),(item.y*Mathf.Cos(Time.time))+(item.x *Mathf.Sin(Time.time)),item.z)* scale;
            temp.Add(newdir+origin);
            /*
            // unity rotation
            Vector3 newdir = rotation * item;
            temp.Add(newdir+origin);
            */
        }

        return temp;
    }
}
