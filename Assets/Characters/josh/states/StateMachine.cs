using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Josh
{
    public class StateMachine : CharacterBase
    {
        public Josh.StateBase currentstate;
        // Start is called before the first frame update
        
        public void ChangeState(Josh.StateBase newstate)
        {
            //check newstate is not current state
            if (newstate != currentstate)
            {
                if(currentstate) currentstate.Exit();
                currentstate = newstate;
                if(currentstate) currentstate.Enter();
            }
        }

        public void EndState()
        {
            ChangeState(null);
        }
    }
}
