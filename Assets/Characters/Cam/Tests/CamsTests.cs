using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamsTests : MonoBehaviour
{
    public Thing aThing;
    public List<Thing> things;
    
    
}

[Serializable]
public class Thing
{
    public int stuff;
    public Vector3 pos;
}