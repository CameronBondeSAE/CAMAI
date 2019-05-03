using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Experimental.UIElements.StyleEnums;

[Serializable]
public class Star
{

    public Vector3 position;
    public Vector3Int colour;
    public SoftwareRenderer rend;

    public Star(float x, float y, Vector3Int c)
    {
        rend = SoftwareRenderer.renderer;
        
        position.x = x;
        position.y = y;
        position.z = 0.5f;

        colour = c;
    }

    public void UpdatePosition(float x, float y, float z)
    {
        position.x = x;
        position.y = y;
        position.z = z; 
    }

    public void SetColour(int r, int g, int b)
    {
        colour.x = r;
        colour.y = g;
        colour.z = b;
    }

}
