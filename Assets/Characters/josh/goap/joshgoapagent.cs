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

    public state currentstate = state.idle;
    public HashSet<joshgoapaction> Avaliableactions = new HashSet<joshgoapaction>();

    public Queue<joshgoapaction> Currentactions = new Queue<joshgoapaction>();

    public joshgoapplanner thunker;
    // Start is called before the first frame update
    void Awake()
    {
        Loadactions();
        thunker = new joshgoapplanner();
        //Queue<joshgoapaction> temp = thunker.MakePlan(Avaliableactions,)
    }

    // Update is called once per frame
    void Update()
    {
        if (Currentactions.Count != 0)
        {
            if (!Currentactions.Peek().Actiondone())
            {
                if (Currentactions.Peek().CheckPreconditions())
                {
                    Currentactions.Peek().ActionMethod();
                }
            }
            else
            {
                Currentactions.Dequeue();
            }
        }
    }

    public void Loadactions()
    {
        foreach (var item in gameObject.GetComponents<joshgoapaction>())
        {
            Avaliableactions.Add(item);
        }
    }
}
