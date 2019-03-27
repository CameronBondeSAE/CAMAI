using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObj : MonoBehaviour
{
    public enum type
    {
        Normal,
        Wall,
        Start,
        End
    }

    public type thistype = type.Normal;

    public type Thistype
    {
        get => thistype;
        set
        {
            thistype = value;
            if(thistype == type.Normal) gameObject.GetComponent<Renderer>().material.color = Color.white;
            if(thistype == type.Wall) gameObject.GetComponent<Renderer>().material.color = Color.grey;
            if(thistype == type.Start) gameObject.GetComponent<Renderer>().material.color = Color.green;
            if(thistype == type.End) gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] items = Physics.OverlapBox(gameObject.transform.position, gameObject.transform.localScale / 2,Quaternion.identity);
        if (items.Length != 0)
        {
            Thistype = type.Wall;
        }
    }
}
