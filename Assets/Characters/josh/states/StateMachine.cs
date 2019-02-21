using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Josh
{
    public class StateMachine : CharacterBase
    {
        public Josh.StateBase currentstate;
        // Start is called before the first frame update

        public void RunState()
        {
            if(currentstate) currentstate.Execute();
        }
        
        public void ChangeState(Josh.StateBase newstate)
        {
            //check newstate is not current state
            if (newstate != currentstate)
            {
                if(currentstate) currentstate.Exit();
                if(newstate) newstate.Enter();
                currentstate = newstate;
            }

            //return newstate != currentstate;
        }

        public void EndState()
        {
            ChangeState(null);
        }
    }
}
