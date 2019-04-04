using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class joshgoapaction : MonoBehaviour
{
    public HashSet<KeyValuePair<string, object>> preconditions;

    public HashSet<KeyValuePair<string, object>> effects;

    public float basecost = 1;

    public GameObject target;
    
    // setup
    
    public joshgoapaction() {
        preconditions = new HashSet<KeyValuePair<string, object>> ();
        effects = new HashSet<KeyValuePair<string, object>> ();
    }

    public abstract bool Actiondone();
    public abstract bool CheckPreconditions();
    public abstract void ActionMethod();
}
