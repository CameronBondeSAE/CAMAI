using System;
using UnityEngine;

public class SoftwareRenderer : MonoBehaviour
{
    public static SoftwareRenderer renderer;
    
    public int xSize, ySize;
    public Renderer quadRenderer;
    private Texture2D tex;

    [HideInInspector]
    public byte[] backBuffer;

    public static event Action Rendering;

    private void Awake()
    {
        // setting static reference
        renderer = GetComponent<SoftwareRenderer>();
        
        SetTexture(); // creating backbuffer and drawing it

    }

    private void Update()
    {
        UpdateTexture();
    }

    [ContextMenu("Update Texture")]
    public void UpdateTexture()
    {
        Wipe();
        // runs rendering event
        if (Rendering != null) Rendering();
        // loading byte array into texture
        tex.LoadRawTextureData(backBuffer);
        tex.Apply(false);
    }
    
    [ContextMenu("Set New Texture")]
    public void SetTexture()
    {
        // generating texture and back buffer
        tex = new Texture2D(xSize, ySize, TextureFormat.RGB24, false);
        backBuffer = new byte[(xSize * ySize) * 3];
        
        tex.filterMode = FilterMode.Point; // This turns off blur for debugging
        quadRenderer.material.mainTexture = tex;
        
        // clearing backbuffer and setting new texture
        Wipe();
        UpdateTexture();
    }

    public float fov = 30f;
    public void Set3DSpecificPixel(float x, float y, float z, Vector3Int c)
    {
        // offsetting x and y according to z pos
        float newX = x / (z * fov);
        float newY = y / (z * fov);

        // creating offset to centre stars at 0,0
        float xCenter = (xSize / 2f);
        float yCenter = (ySize / 2f);

        SetSpecificPixel((int)(newX + xCenter),(int)(newY + yCenter), z, c);
        
    }
    
    public void SetSpecificPixel(int x, int y, float z, Vector3Int c)
    {
        // checks to not draw stuff if its out of range
        if (((y * xSize) + x) * 3 >= (xSize * ySize * 3) - 2) return;

        if (x < 0 || x > xSize - 1) return;
        if (y < 0 || y > ySize) return;
        if (z < 0) return;
        
        // colouring pixels at location according to their colour
        backBuffer[((y * xSize) + x) * 3] = (byte)c.x;
        backBuffer[(((y * xSize) + x) * 3) + 1] = (byte)c.y ;
        backBuffer[(((y * xSize) + x) * 3) + 2] = (byte)c.z;
        
    }

    private void Wipe()
    {
        // wipes back buffer totally clean
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j < xSize; j++)
            {
                backBuffer[((i * xSize) + j) * 3] = 0;
                backBuffer[(((i * xSize) + j) * 3) + 1] = 0;
                backBuffer[(((i * xSize) + j) * 3) + 2] = 0;
            }
        }
        
    }
    
}
