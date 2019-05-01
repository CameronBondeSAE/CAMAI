using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class SpinnerSensor : ReGoapSensor<string,object>
    {

        public WhosAround checkAround;
        public Spinner_Model spinner;
        public Health health;

        private void Awake()
        {
            spinner = GetComponent<Spinner_Model>();
            checkAround = GetComponent<WhosAround>();
        }

        public override void UpdateSensor()
        {
            base.UpdateSensor();
            if (spinner.Target)
            {
                
                //GetMemory().GetWorldState().Set("hasTarget", true);
            }
            //else GetMemory().GetWorldState().Set("hasTarget", false);

            if (health.Amount != 0f)
            {
                GetMemory().GetWorldState().Set("alive", true);
            }
        }
    }


}
