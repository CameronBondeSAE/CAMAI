using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michael
{
    public class FollowState : StateBase
    {
        public override void Execute()
        {
            base.Execute();
            if (Self.GetComponent<Darkling_Model>().vestraLead)
            {
                Self.GetComponent<CharacterBase>().Move(Self.GetComponent<Darkling_Model>().vestraLead.transform.position);
            }
            else
            {
                Exit();
            }
        }
    }
}
