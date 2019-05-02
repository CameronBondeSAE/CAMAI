using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshManager : MonoBehaviour
{

    private SoftwareRenderer rend;
    public Mesh mesh;
    public float zSpeed = 1;
    public float rSpeed = 1;

    // Start is called before the first frame update
    private void Start()
    {
        rend = SoftwareRenderer.renderer;
    
        mesh = new Mesh(0,0,2);
        
        SoftwareRenderer.Rendering += SetMesh;
    }

    private void UpdateMeshDetails()
    {
        // movement for testing perspective of cube
        mesh.UpdatePosition(mesh.position.x, mesh.position.y ,mesh.position.z + (zSpeed * Time.deltaTime));
        mesh.UpdateRotation(mesh.rotation.x, mesh.rotation.y, mesh.rotation.z + (rSpeed * Time.deltaTime));

    }
    
    private void UpdateMeshRotation()
    {
        // to do
    }

    public void SetMesh()
    {
        UpdateMeshDetails();
        // takes vertices of mesh and displays them in 3D on renderer
        foreach (Vertex v in mesh.vertices)
        {
            rend.Set3DSpecificPixel((v.position.x + mesh.position.x) * mesh.scale.x, (v.position.y + mesh.position.y)* mesh.scale.y, (v.position.z + mesh.position.z) * mesh.scale.z, v.colour);  
        }
    }

}
