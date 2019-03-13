using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class starfield : MonoBehaviour
{
    //public Vector3 camerapos = Vector3.zero;

    public float maxdist = 10;
    public float maxsize = 5;
    public float fovdist = 1;
    public Queue<Vector3> stars = new Queue<Vector3>();

    public int numstars = 1;

    public rendertex viewer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numstars; i++)
        {
            stars.Enqueue(new Vector3(Random.value,Random.value,Random.Range(1-(1/maxdist),1)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        viewer.Setall(0,0,0);
        //stars = new Queue<Vector3>(stars.OrderBy(o => 1-o.z));
        for (int i = 0; i < numstars; i++)
        {
            render2();
        }

        /*
        foreach (Vector3 item in stars)
        {
            float check = 2;
            if()
        }
        */
        
    }

    public void render()
    {
        Vector3 temp = stars.Dequeue();
        temp.z -= 1/maxdist;
        if (calcposition(temp).x <=1 && calcposition(temp).y <=1)//(temp.z > 0)
        {
            float temp2 = Mathf.Lerp(255,0,temp.z);
            viewer.SetBlock((int)((calcposition(temp).x)*viewer.sizex),(int)((calcposition(temp).y)*viewer.sizey),(int)Mathf.Lerp(maxsize,1,temp.z),(int)temp2,(int)temp2,(int)temp2);
            //viewer.SetPixel((int)((calcposition(temp).x)*viewer.sizex),(int)((calcposition(temp).y)*viewer.sizey),(int)temp2,(int)temp2,(int)temp2);
                
            //viewer.SetPixel((int)(temp.x*viewer.sizex),(int)(temp.y*viewer.sizey),(int)temp2,(int)temp2,(int)temp2);
            //viewer.SetBlock((int)(temp.x*viewer.sizex),(int)(temp.y*viewer.sizey),(int)Mathf.Lerp(maxsize,1,temp.z),(int)temp2,(int)temp2,(int)temp2);
            //Debug.Log(new Vector2(calcposition(temp).x*viewer.sizex,calcposition(temp).y*viewer.sizey));
            stars.Enqueue(temp);
        }
        else
        {
            stars.Enqueue(new Vector3(Random.value,Random.value,Random.Range(1-(1/maxdist),1)));
            //stars = new Queue<Vector3>(stars.OrderBy(o => 1-o.z));
        }
    }

    public void render2()
    {
        Vector3 temp = stars.Dequeue();
        temp.z -= 1/maxdist;
        if (calcposition(temp).x <=1 && calcposition(temp).y <=1)//(temp.z > 0)
        {
            float temp2 = Mathf.Lerp(255,0,temp.z);
            viewer.SetBlock((int)Mathf.Clamp(calcposition2(temp).x*viewer.sizex,0,viewer.sizex),(int)Mathf.Clamp(calcposition2(temp).y*viewer.sizey,0,viewer.sizex),(int)Mathf.Lerp(maxsize,1,temp.z),(int)temp2,(int)temp2,(int)temp2);
            //viewer.SetPixel((int)Mathf.Clamp(calcposition2(temp).x*viewer.sizex,0,viewer.sizex),(int)Mathf.Clamp(calcposition2(temp).y*viewer.sizey,0,viewer.sizey),(int)temp2,(int)temp2,(int)temp2);
                
            //viewer.SetPixel((int)(temp.x*viewer.sizex),(int)(temp.y*viewer.sizey),(int)temp2,(int)temp2,(int)temp2);
            //viewer.SetBlock((int)(temp.x*viewer.sizex),(int)(temp.y*viewer.sizey),(int)Mathf.Lerp(maxsize,1,temp.z),(int)temp2,(int)temp2,(int)temp2);
            //Debug.Log(new Vector2(calcposition(temp).x*viewer.sizex,calcposition(temp).y*viewer.sizey));
            stars.Enqueue(temp);
        }
        else
        {
            stars.Enqueue(new Vector3(Random.value,Random.value,Random.Range(1-(1/maxdist),1)));
            //stars = new Queue<Vector3>(stars.OrderBy(o => 1-o.z));
        }
    }

    public Vector2 calcposition(Vector3 item)
    {
        //Y = fovdist*y/(z+fovdist)
        float distance = fovdist + item.z;
        Vector2 temp = new Vector2((item.x/distance),(item.y/distance))*fovdist;

        return temp;
    }
    public Vector2 calcposition2(Vector3 item)
    {
        //Y = fovdist*y/(z+fovdist)
        float distance = fovdist + item.z;
        Vector2 test = new Vector2(((item.x-0.5f) / distance), ((item.y-0.5f) / distance)) * fovdist;
        
        return new Vector2(test.x+0.5f,test.y+0.5f);
    }
}
