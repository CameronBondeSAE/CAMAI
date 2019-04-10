using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class joshgoapplanner
{
    public Queue<joshgoapaction> MakePlan(HashSet<joshgoapaction> availableActions,HashSet<KeyValuePair<string,object>> goal, HashSet<KeyValuePair<string,object>> worldstate)
    {
        HashSet<joshgoapaction> usableactions = new HashSet<joshgoapaction>();
        foreach (joshgoapaction item in availableActions)
        {
            if (item.CheckPreconditions())
            {
                usableactions.Add(item);
            }
        }

        List<joshstatetree> validpaths = new List<joshstatetree>();
        joshstatetree start = new joshstatetree(null, 0, worldstate,null);
        bool succeeded = buildtree(start, validpaths, usableactions, goal);
        if (!succeeded)
        {
            Debug.Log("no valid plan found to goal");
            return null;
        }
        
        // get the cheapest path
        joshstatetree cheapest = null;
        foreach (joshstatetree path in validpaths) {
            
            
            //Debug.Log(path.action);
            //Debug.Log(path.parent.action);
            //Debug.Log(path.parent.parent?.action);
            
            //Debug.Log(path.parent.action);
            if (cheapest == null)
                cheapest = path;
            else {
                if (path.totalcost < cheapest.totalcost)
                    cheapest = path;
            }
        }
        
        // get a finished path and go back through it's parents
        List<joshgoapaction> result = new List<joshgoapaction> ();
        joshstatetree n = cheapest;
        while (n != null) {
            //Debug.Log(n.action);
            if (n.action != null) {
                result.Insert(0, n.action); // insert the action in the front
            }
            n = n.parent;
        }

        Queue<joshgoapaction> queue = new Queue<joshgoapaction> ();
        foreach (joshgoapaction a in result) {
            //Debug.Log(a);
            queue.Enqueue(a);
        }

        // hooray we have a plan!
        return queue;
    }

    public bool buildtree(joshstatetree start, List<joshstatetree> tree, HashSet<joshgoapaction> usableactionset,HashSet<KeyValuePair<string, object>> goal)
    {
        bool pathfound = false;
        foreach (joshgoapaction item in usableactionset)
        {
            bool temp = containsstate(start.worldstate, item.preconditions, false);//item.target!=null&&start.parent==null);
            //Debug.Log(item+" "+temp);
            if (temp)
            {
                HashSet<KeyValuePair<string,object>> alteredState = applystate(start.worldstate,item.effects);
                joshstatetree node = new joshstatetree(start,start.totalcost+item.basecost,alteredState,item);
                if (containsstate(alteredState, goal,false))
                {
                    tree.Add(node);
                    pathfound = true;
                }
                else
                {
                    // recursively look through states below this one
                    // todo figure out the logic behind stopping an action from being run several times
                    HashSet<joshgoapaction> subset = actionSubset(usableactionset,item);
                    //subset.Remove(item);
                    bool found = buildtree(node, tree, subset, goal);
                    if (found) pathfound = true;
                }
            }
        }

        return pathfound;
    }

    public bool containsstate(HashSet<KeyValuePair<string, object>> set, HashSet<KeyValuePair<string, object>> state, bool deb)
    {
        /*
        if (deb)
        {
            Debug.Log("debuger");
            foreach (var temp in set)
            {
                Debug.Log(temp);
            }
        }
        */
        bool allmatch = true;
        foreach (var item in state)
        {
            bool currentmatch = false;
            foreach (var item2 in set)
            {
                if (deb)
                {
                    
                    //Debug.Log(item.Key+" "+item.Value + " "+item2.Key+" "+item2.Value + " "+item2.Equals(item));
                }
                if (item2.Key == item.Key)
                {
                    if (item2.Equals(item))
                    {
                        currentmatch = true;
                        break;
                    }
                }
            }
        
            if (!currentmatch)allmatch = false;
            /*
            else
            {
                foreach (var item2 in set)
                {
                    if (item.Key == item2.Key)
                    {
                        if (!item.Equals(item2))
                        {
                            return false;
                        }
                    }
                }
            }
            */
        }

        return allmatch;
    }

    public HashSet<KeyValuePair<string, object>> applystate(HashSet<KeyValuePair<string, object>> current, HashSet<KeyValuePair<string, object>> dif)
    {
        HashSet<KeyValuePair<string, object>> newstate = new HashSet<KeyValuePair<string, object>>(current);
        foreach (var item in dif)
        {
            if (newstate.Contains(item))
            {
                // exists, remove it and add the updated one
                newstate.RemoveWhere( (KeyValuePair<string,object> a) => { return a.Key.Equals (item.Key); } );
                newstate.Add(item);
            }
            else
            {
                // does not exist, add it
                newstate.Add(item);
            }
        }

        return newstate;
    }
    
    public HashSet<joshgoapaction> actionSubset(HashSet<joshgoapaction> actions, joshgoapaction removeMe) {
        HashSet<joshgoapaction> subset = new HashSet<joshgoapaction> ();
        foreach (joshgoapaction a in actions) {
            if (!a.Equals(removeMe))
                subset.Add(a);
        }
        return subset;
    }
}
