using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class SpinnerAgent : ReGoapAgent<string,object>
    {
        public AttackEnemy attack;
        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            //
        }


        void Start()
        {
            Recal();
        }

        // Update is called once per frame
        void Update()
        {    
        
        }

        public void Recal()
        {
            CalculateNewGoal(true);
        }
    }


}
