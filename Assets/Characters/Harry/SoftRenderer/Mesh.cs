using System;
using UnityEngine;

[Serializable]
public class Mesh
{

    public Vector3 position;
    public Vector3 rotation;
    private Vertex[] originalVertices;
    public Vertex[] vertices;
    public Vector3 scale;

    public Mesh(float x, float y, float z)
    {
        // sets position to input
        position.x = x;
        position.y = y;
        position.z = z;
        
        // white pixels
        Vector3Int c = new Vector3Int(255,255,255);
        // default scale
        scale = Vector3.one;
        
        
        // SETUP FOR A CUBE
        originalVertices = new Vertex[8];
        
        originalVertices[0] = new Vertex(0.5f,0.5f,0.5f,c);
        originalVertices[1] = new Vertex(0.5f,-0.5f,0.5f,c);
        originalVertices[2] = new Vertex(0.5f,-0.5f,-0.5f,c);
        originalVertices[3] = new Vertex(0.5f,0.5f,-0.5f,c);
        originalVertices[4] = new Vertex(-0.5f,0.5f,0.5f,c);
        originalVertices[5] = new Vertex(-0.5f,-0.5f,0.5f,c);
        originalVertices[6] = new Vertex(-0.5f,-0.5f,-0.5f,c);
        originalVertices[7] = new Vertex(-0.5f,0.5f,-0.5f,c);
        
        // assigning vertices 
        vertices = originalVertices;
    }

    public void UpdateRotation(float x, float y, float z)
    {
        rotation.x = x;
        rotation.y = y;
        rotation.z = z;

        // ROTATE ALONG Z AXIS
        for (int i = 0; i < originalVertices.Length; i++)
        {
            float newX = (Mathf.Cos(rotation.z) * originalVertices[i].position.x) + (-Mathf.Sin(rotation.z) * originalVertices[i].position.y);
            float newY = (Mathf.Sin(rotation.z) * originalVertices[i].position.x) + (Mathf.Cos(rotation.z) * originalVertices[i].position.y);
            
            vertices[i].position.x = newX;
            vertices[i].position.y = newY;
        }
    }
    
    public void UpdatePosition(float x, float y, float z)
    {
        position.x = x;
        position.y = y;
        position.z = z; 
    }
}