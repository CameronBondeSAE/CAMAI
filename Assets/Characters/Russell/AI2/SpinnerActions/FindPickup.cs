using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class FindPickup : ReGoapAction<string,object>
    {
        public List<GameObject> EnergyPickups = new List<GameObject>();
        public float minDist = Mathf.Infinity;
        public Transform newPos;
        protected override void Awake()
        {
            base.Awake();
            preconditions.Set("alive", true);
            effects.Set("foundPickup", true);
            
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
            Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            FindNearestEnergyPickups();
            StartCoroutine(WaitASec());
            //this.gameObject.transform.position = newPos.position;
            

        }



        public void FindNearestEnergyPickups()
        {
            EnergyPickups.Add(FindObjectOfType<EnergyPickup>().gameObject);
            foreach (var pickup in EnergyPickups)
            {
                float dist = Vector3.Distance(pickup.transform.position, this.gameObject.transform.position);
                if (dist < minDist)
                {    
                    newPos = pickup.transform;
                    minDist = dist;
                }
            }            
        }
        
        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);
            var worldState = agent.GetMemory().GetWorldState();
            foreach (var pair in effects.GetValues())
            {
                worldState.Set(pair.Key,pair.Value);
            }
        }
        IEnumerator WaitASec()
        {
            yield return new WaitForSeconds(1);
            doneCallback(this);
        }
    }
    

}

