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
            Self.GetComponent<CharacterBase>().Move(Self.GetComponent<Darkling_Model>().vestraLead.transform.position);
        }
    }
}
