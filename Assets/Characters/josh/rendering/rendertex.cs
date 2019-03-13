using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rendertex : MonoBehaviour
{
    public int sizex;
    public int sizey;
    public Renderer texrender;
    private Texture2D tex;
    public byte[] backbuffer;
    // Start is called before the first frame update
    void Start()
    {
        tex = new Texture2D(sizex,sizey,TextureFormat.RGB24,false);
        tex.filterMode = FilterMode.Point;
        texrender.material.mainTexture = tex;
        SetBlock(4,4,3,20,100,50);
        //SetPixel(1,1,20,100,50);
        //Setall(20,100,50);
    }

    // Update is called once per frame
    void Update()
    {
        //SetPixel(Random.Range(0,sizex),Random.Range(0,sizey),Random.Range(0,255),Random.Range(0,255),Random.Range(0,255));
        tex.LoadRawTextureData(backbuffer);
        tex.Apply(false);
    }

    public void SetPixel(int x, int y, int red, int green, int blue)
    {
        if (x > sizex - 1 || y > sizey - 1 || red > 255 || green > 255 || blue > 255)
        {
            return;
        }
        int filled = (y * sizex + x)*3;
        backbuffer[filled] = (byte)red;
        backbuffer[filled+1] = (byte)green;
        backbuffer[filled+2] = (byte)blue;
        
    }
    public void SetPixelCenter(int x, int y, int red, int green, int blue)
    {
        if (x > sizex/2 || y > sizey/2 || x < -sizex/2 || y < -sizey/2 || red > 255 || green > 255 || blue > 255)
        {
            return;
        }
        int filled = ((y+sizey/2) * sizex + (x+sizex/2))*3;
        backbuffer[filled] = (byte)red;
        backbuffer[filled+1] = (byte)green;
        backbuffer[filled+2] = (byte)blue;
        
    }
    
    public void SetBlock(int x, int y, int size, int red, int green, int blue)
    {
        if (x > sizex - 1 || y > sizey - 1 || size == 0|| red > 255 || green > 255 || blue > 255)
        {
            return;
        }

        for (int i = 0; i < sizex; i++) // x pos
        {
            for (int a = 0; a < sizey; a++) // y pos
            {
                //Debug.Log(x - size < i);
                if (x - size < i && i< x+size)
                {
                    if (y-size < a && a< y+size)
                    {
                        //Debug.Log("draw" + (size) + " " + (x));
                        SetPixel(i,a,red,green,blue);
                    }
                }
            }
        }
        
        
        
    }

    public void Setall(int red, int green, int blue)
    {
        if (red > 255 || green > 255 || blue > 255)
        {
            return;
        }
        for (int i = 0; i < backbuffer.Length; i+=3)
        {
            backbuffer[i] = (byte)red;
            backbuffer[i+1] = (byte)green;
            backbuffer[i+2] = (byte)blue;
        }
        
    }
}
