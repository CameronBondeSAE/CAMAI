using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Russell
{
    
    public class FindEnemyAction : ReGoapAction<string,object>
    {
        
        Spinner_Model model;
        public List<GameObject> whosAround = new List<GameObject>();
        private WhosAround checkEnemys;
        protected override void Awake()
        {
            
            
            base.Awake();
            model = GetComponent<Spinner_Model>();      
            preconditions.Set("alive", true);
            effects.Set("foundEnemy", true);
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
            Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            StartCoroutine(WaitASec());
        }
        
        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);
            var worldState = agent.GetMemory().GetWorldState();
            foreach (var pair in effects.GetValues())
            {
                worldState.Set(pair.Key,pair.Value);
            }
            whosAround.Clear();
        }
        
        
        IEnumerator WaitASec()
        {
            yield return new WaitForSeconds(1);
            FindNearestEnemy();
            doneCallback(this);
        }
        
        IEnumerator Failed()
        {
            yield return new WaitForSeconds(1);
            
        }
        
        /*private void OnTriggerEnter(Collider other)
        {
        
            if (other.GetComponent<CharacterBase>())
            {
                whosAround.Add(other.gameObject);
                //numberOfPlayers = whosAround.Count;
            }
        }
        private void OnTriggerExit(Collider other)
        { 
            whosAround.Remove(other.gameObject);  
            //numberOfPlayers = whosAround.Count;
        }*/
        public float minDist = Mathf.Infinity;
        public GameObject newTarget;
        public void FindNearestEnemy()
        {
            whosAround.Add(FindObjectOfType<CharacterBase>().gameObject);
            foreach (var enemy in whosAround)
            {
                float dist = Vector3.Distance(enemy.transform.position, this.gameObject.transform.position);
                if (dist < minDist)
                {    
                    newTarget = enemy;
                    minDist = dist;
                }
            }

            model.Target = newTarget;
        }
    }


}
