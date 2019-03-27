using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public int xsize = 1;

    public int ysize = 1;

    public GameObject TilePrefab;

    public List<GameObject> world;
    // Start is called before the first frame update
    void Start()
    {
        for (float i = 0; i < xsize; i++)
        {
            for (float j = 0; j < ysize; j++)
            {
                GameObject temp = Instantiate(TilePrefab, new Vector3(i * 5, 0, j * 5), Quaternion.identity);
                float temp2 = Mathf.PerlinNoise(7*i/xsize, 7*j/ysize);
                if (temp2 > 0.5f) temp.GetComponent<TileObj>().Thistype = TileObj.type.Wall;
                world.Add(temp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
