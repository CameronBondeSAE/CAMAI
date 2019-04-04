using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class joshstatetree
{
    public List<joshstatetree> Node = new List<joshstatetree>();
    [CanBeNull] public joshstatetree parent;
    public float totalcost = 0;
    public HashSet<KeyValuePair<string, object>> worldstate;
    [CanBeNull] public joshgoapaction action;

    public joshstatetree(joshstatetree root, float total, HashSet<KeyValuePair<string, object>> state, joshgoapaction act)
    {
        parent = root;
        totalcost = total;
        worldstate = state;
        action = act;
    }
}
