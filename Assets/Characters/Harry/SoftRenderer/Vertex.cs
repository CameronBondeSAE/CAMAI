using System;
using UnityEngine;

[Serializable]
public class Vertex
{

    public Vector3 position;
    public Vector3Int colour;
    public SoftwareRenderer rend;

    public Vertex(float x, float y, float z, Vector3Int c)
    {
        rend = SoftwareRenderer.renderer;
        
        position.x = x;
        position.y = y;
        position.z = z;

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
