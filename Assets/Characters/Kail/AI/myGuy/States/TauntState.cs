﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Kail
{

    public class TauntState : StateBase
    {

        public Radar target;
        public MyGuyController myGuyTaunt;

        public CharacterBase enemy;
        public CharacterBase me;

        public CharacterBase empty;

        public string insult;


        private void Awake()
        {
            target = GetComponent<Radar>();
            myGuyTaunt = GetComponent<MyGuyController>();
        }

        public override void Enter()
        {
            base.Enter();
            
            
            
            enemy = target.posTarget.GetComponent<CharacterBase>();
            me = GetComponent<CharacterBase>();
            empty = GetComponentInChildren<CharacterBase>();

            //saves the original damage multiplier so it can be reset once taunt stops
            empty.DamageMultiplier = enemy.DamageMultiplier;  
            
            enemy.DamageMultiplier = enemy.DamageMultiplier * (0.25f * me.DamageMultiplier);


        }

        public override void Update()
        {
            //look at enemy
            if (myGuyTaunt.currentState == myGuyTaunt.tauntState)
            {

                transform.LookAt(target.posTarget.transform.position);

                /*sets the rotation.x to 0f, because i want that
                var tempRot = new Quaternion();
                tempRot.Set(0f, transform.rotation.y, 0f, 1);
                transform.rotation = tempRot;*/
                
                target.tarDistance = Vector3.Distance(target.transform.position, transform.position);
                
            }

        }


        public void SetInsult()
        {
            var insultChoose = UnityEngine.Random.Range(0, 3);
            switch (insultChoose)
            {
                case 0:
                    insult = "You fight like someone who can't fight well!";
                    break;
                case 1:
                    insult = "Nanananana, you can't catch me.";
                    break;
                case 2:
                    insult = "I'm mad AND disappointed!";
                    break;
                case 3:
                    insult = "GitGud";
                    break;
            }
            
        }

        public override void Exit(int nextState)
        {

            base.Exit(nextState);
            enemy.DamageMultiplier = empty.DamageMultiplier;
            switch (nextState)
            {
                case 0:
                    GetComponent<Radar>().TargetNotFound();
                    GetComponent<Renderer>().material.color = Color.gray;
                    break;
                case 2:
                    GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                default:
                    GetComponent<Renderer>().material.color = Color.black;
                    break;
                
            }
            
            
        }
    }
}
