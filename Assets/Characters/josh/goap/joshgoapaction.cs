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

    public void AddPre(string key, object val)
    {
        preconditions.Add(new KeyValuePair<string, object>(key,val));
    }
    public void AddPost(string key, object val)
    {
        effects.Add(new KeyValuePair<string, object>(key,val));
    }

    public void RemovePre(string key)
    {
        // check over later
        KeyValuePair<string, object> remove = default(KeyValuePair<string,object>);
        foreach (KeyValuePair<string, object> kvp in preconditions) {
            if (kvp.Key.Equals (key)) 
                remove = kvp;
        }
        if ( !default(KeyValuePair<string,object>).Equals(remove) )
            preconditions.Remove (remove);
    }
    public void RemovePost(string key)
    {
        // check over later
        KeyValuePair<string, object> remove = default(KeyValuePair<string,object>);
        foreach (KeyValuePair<string, object> kvp in effects) {
            if (kvp.Key.Equals (key)) 
                remove = kvp;
        }
        if ( !default(KeyValuePair<string,object>).Equals(remove) )
            effects.Remove (remove);
    }

    public abstract bool Actiondone();
    public abstract bool CheckPreconditions();
    public abstract bool ActionMethod(GameObject agent);
}
