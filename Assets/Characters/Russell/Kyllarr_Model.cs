using System.Collections;
using System.Collections.Generic;
using Russell;
using UnityEngine;

public class Kyllarr_Model : CharacterBase
{


    public StateBase currentState;
    public StateBase attackState;
    public StateBase rotateState;

    public void ChangeState(StateBase newState)
    {
        //Check state is not the same
        currentState.Exit();
        newState.Enter();
        currentState = newState;
        
    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    
    

    // Update is called once per frame
    public void Update()
    {
        currentState.Execute();
    }
}
