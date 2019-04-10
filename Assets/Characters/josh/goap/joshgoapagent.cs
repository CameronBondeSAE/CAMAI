using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joshgoapagent : MonoBehaviour
{
    public enum state
    {
        idle,
        runningaction
    }

    public bool awake = true;
    public GameObject target;

    public state currentstate = state.idle;
    public HashSet<joshgoapaction> Avaliableactions = new HashSet<joshgoapaction>();

    public Queue<joshgoapaction> Currentactions = new Queue<joshgoapaction>();
    
    public HashSet<KeyValuePair<string,object>> goalstate = new HashSet<KeyValuePair<string, object>>();

    public joshgoapplanner thunker;
    // Start is called before the first frame update
    void Awake()
    {
        Loadactions();
        thunker = new joshgoapplanner();
        Currentactions = thunker.MakePlan(Avaliableactions, createGoalState(),getWorldState());
    }

    // Update is called once per frame
    void Update()
    {
        if (Currentactions != null)
        {
            if (Currentactions.Count != 0)
            {
                if (!Currentactions.Peek().Actiondone())
                {
                    if (Currentactions.Peek().CheckPreconditions())
                    {
                        Currentactions.Peek().ActionMethod(gameObject);
                    }
                    else
                    {
                        // make new plan
                        Debug.Log("thinking plan");
                        Currentactions = thunker.MakePlan(Avaliableactions, createGoalState(),getWorldState());
                    }
                }
                else
                {
                    Currentactions.Dequeue();
                }
            }
            else
            {
                // make new plan
                Debug.Log("thinking plan");
                Currentactions = thunker.MakePlan(Avaliableactions, createGoalState(),getWorldState());
            }
        }
        else
        {
            // make new plan
            Debug.Log("thinking plan");
            Currentactions = thunker.MakePlan(Avaliableactions, createGoalState(),getWorldState());
        }
    }

    public void Loadactions()
    {
        foreach (var item in gameObject.GetComponents<joshgoapaction>())
        {
            Avaliableactions.Add(item);
        }
    }
    
    public HashSet<KeyValuePair<string,object>> createGoalState () {
        HashSet<KeyValuePair<string,object>> goal = new HashSet<KeyValuePair<string,object>> ();
		
        goal.Add(new KeyValuePair<string, object>("awake", true ));
        goal.Add(new KeyValuePair<string, object>("attarget", true ));
        return goal;
    }
    public HashSet<KeyValuePair<string,object>> getWorldState () {
        HashSet<KeyValuePair<string,object>> worldData = new HashSet<KeyValuePair<string,object>> ();

        worldData.Add(new KeyValuePair<string, object>("attarget", Vector3.Distance(target.transform.position, gameObject.transform.position) < 0.5f ));
        worldData.Add(new KeyValuePair<string, object>("awake", awake));
        //Debug.Log("state "+awake+" "+(Vector3.Distance(target.transform.position, gameObject.transform.position) < 0.5f));

        return worldData;
    }
}
