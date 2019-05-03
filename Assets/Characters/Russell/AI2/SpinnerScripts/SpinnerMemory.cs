using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class SpinnerMemory : ReGoapMemory<string,object>
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            GetComponent<AttackEnemy>().RePlan += ReDo;
            GetWorldState().Set("alive", true);
            GetWorldState().Set("foundEnemy", false);
            GetWorldState().Set("foundPickup", false);
            GetWorldState().Set("fullEnergy", false);
            GetWorldState().Set("EnemyDamaged", false);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void ReDo()
        {
            GetWorldState().Set("foundEnemy", false);
            GetWorldState().Set("foundPickup", false);
            GetWorldState().Set("fullEnergy", false);
            GetWorldState().Set("EnemyDamaged", false);
        }
    }


}
    