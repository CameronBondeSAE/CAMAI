using System;
using System.Collections;
using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity;
using UnityEngine;

namespace Russell
{
    public class MoveAction : ReGoapAction<string,object>
    {
        public float movementSpeed;

        private Spinner_Model model;
        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            model = GetComponent<Spinner_Model>();

            preconditions.Set("alive", true);
            effects.Set("haveMoved", true);
        }

        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, Action<IReGoapAction<string, object>> done,
            Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);
            Move();
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
        }
        
        IEnumerator WaitASec()
        {
            yield return new WaitForSeconds(5);
            if (!model.Target)
            {
                failCallback(this);
            }
        }

        public void Move()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 10;
            
            Ray ray;
            ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            var origin = transform.position;
            if (Physics.Raycast(origin, Quaternion.AngleAxis(20f, transform.right) * transform.forward, out hit, 8f))
            {
                
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                if (Physics.Raycast(ray, out hit, 50f))
                {
                    
                    rb.AddForce(0, 0, movementSpeed * Time.deltaTime);
                    if (Physics.Raycast(origin, Quaternion.AngleAxis(45f, transform.up) * transform.forward,
                        out hit, 10f))
                        rb.transform.Rotate(0, -80 * Time.deltaTime, 0);
                    else if (Physics.Raycast(origin, Quaternion.AngleAxis(-45f, transform.up) * transform.forward,
                        out hit, 10f)) rb.transform.Rotate(0, 80 * Time.deltaTime, 0);

                    if (Physics.Raycast(origin, Quaternion.AngleAxis(90f, transform.up) * transform.forward,
                        out hit,
                        5f))
                        rb.transform.Rotate(0, -120 * Time.deltaTime, 0);
                    if (Physics.Raycast(origin, Quaternion.AngleAxis(-90f, transform.up) * transform.forward,
                        out hit,
                        5f))
                        rb.transform.Rotate(0, 120 * Time.deltaTime, 0);
                }
            }
        }


    }


}
