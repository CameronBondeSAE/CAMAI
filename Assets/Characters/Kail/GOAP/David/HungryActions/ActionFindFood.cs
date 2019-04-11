using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using NodeCanvas.Tasks.Actions;
using ReGoap.Core;
using ReGoap.Unity;
using ReGoap.Unity.FSMExample.Actions;
using ReGoap.Unity.FSMExample.FSM;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Kail
{
    public class ActionFindFood : ReGoapAction<string, object>
    {
        public GameObject foundObj; //the object found
        public GameObject pickedFood; //the food you pick 

        public ChildScript child;
        
        public List<DetsFood> foodWanted;//food at the level you want
        public List<DetsFood> foodAbove;//food above the level you want
        public List<DetsFood> foodBelow;//food below the level you want
        
        //used to handle the turning around
        private bool turn;
        private bool pause;
        private Quaternion pos;
        private Rigidbody rb;
        
        
        protected override void Awake()
        {
            base.Awake();
            Name = "actionFindFood";

            preconditions.Set("childHungry", true);
            preconditions.Set("foundFood", false);
            effects.Set("foundFood", true);
            //effects.Set("pickedFood", pickedFood);

            //find needed components
            rb = GetComponentInParent<Rigidbody>();
            child = GameObject.FindWithTag("child").GetComponent<ChildScript>();
            
            //set up lists
            foodAbove = new List<DetsFood>();
            foodBelow = new List<DetsFood>();
            foodWanted = new List<DetsFood>();
        }
        
        public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next,
            ReGoapState<string, object> settings, ReGoapState<string, object> goalState,
            Action<IReGoapAction<string, object>> done, Action<IReGoapAction<string, object>> fail)
        {
            base.Run(previous, next, settings, goalState, done, fail);

            //set up rotation
            turn = true;
            pause = false;
            pos = this.transform.rotation;
            
        }

        private void Update()
        {
            if ((turn == true) && (pause == false))
            {
                //turn
                rb.AddRelativeTorque(0,30,0);
                turn = false;

                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
                {
                    foundObj = hit.collider.gameObject;
                    FoundSomething();
                }
                
            }

            if ((this.transform.rotation != pos) && (pause == false))
            {
                //turn
                rb.AddRelativeTorque(0,30,0);
                //cast raycast
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit))
                {
                    foundObj = hit.collider.gameObject;
                    FoundSomething();
                }
            }
            
            if ((turn == false) && (this.transform.rotation == pos))
            {
                //goto picker
                PickFood();
            }
        }

        public void FoundSomething()
        {
            pause = true;
            DetsFood foodFound = foundObj.GetComponent<DetsFood>();
            //check if you found food
            if (foodFound == null)
            {
                //if no, pause ends
                pause = false;
            }
            else
            {
                //food was food
                if (foodFound.useable == false)
                {
                    //you cant reach this food, ignore it
                    pause = false;
                }
                else
                {
                    //add food to the necessary ground
                    if (child.hungry == foodFound.hunger) foodWanted.Add(foodFound); //add to middle list
                    if (child.hungry < foodFound.hunger) foodAbove.Add(foodFound); //add to above list
                    if (child.hungry > foodFound.hunger) foodBelow.Add(foodFound); //add to under list
                    pause = false;
                }
                
            }
        }

        public void PickFood()
        {
            //placeholders while i'm messing with things
            GameObject pickThis = new GameObject();
            
            //go through the lists and pick the most fitting food
            if (foodWanted.Count == 1)
            {
                pickedFood = foodWanted[0].gameObject;
                doneCallback(this);
            }

            if (foodWanted.Count > 1)
            {
                //pick the food with the highest health
                foreach (var i in foodWanted)
                {
                    if (pickThis == null) pickThis = i.gameObject;
                    if (i.health > pickThis.GetComponent<DetsFood>().health)
                    {
                        pickThis = i.gameObject;
                    }
                }
                //set the item
                pickedFood = pickThis;
                //end
                doneCallback(this);
            }

            if ((foodWanted.Count == 0) && (foodBelow.Count >= 1))
            {
                //pick the highest food below
                foreach (var i in foodBelow)
                {
                    if (pickThis == null) pickThis = i.gameObject;
                    if (i.hunger > pickThis.GetComponent<DetsFood>().hunger)
                    {
                        pickThis = i.gameObject;
                    }
                }
                //set the item
                pickedFood = pickThis;
                //end
                doneCallback(this);
            }

            if ((foodWanted.Count == 0) && (foodBelow.Count == 0) && (foodAbove.Count >= 1))
            {
                //pick the lowest foodAbove
                foreach (var i in foodAbove)
                {
                    if (pickThis == null) pickThis = i.gameObject;
                    if (i.hunger < pickThis.GetComponent<DetsFood>().hunger)
                    {
                        pickThis = i.gameObject;
                    }
                }
                //set the item
                pickedFood = pickThis;
                //end
                doneCallback(this);
            }

            else
            {
                failCallback(this);
            }
            
        }

        public override void Exit(IReGoapAction<string, object> next)
        {
            base.Exit(next);

            var worldState = agent.GetMemory().GetWorldState();
            worldState.Set("foundFood", true);
        }
        
    }
    
    
}