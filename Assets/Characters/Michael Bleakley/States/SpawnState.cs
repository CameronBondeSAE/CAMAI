using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kennith;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Michael
{
    public class SpawnState : StateBase
    {
        [SerializeField] private GameObject darklingPrefab;
        [SerializeField] private GameObject vestraPrefab;
        private float counter;
        public List<GameObject> darklings;
        [SerializeField]
        private int cost;

        private Kennith_Model[] _kennithModel;

        private void Start()
        {
            darklings = new List<GameObject>();
        }

        public override void Enter()
        {
            Invoke("Spawn", delay);
            
        }

        private void newVestra()
        {
            Vector3 temp = new Vector3(Random.Range(-10,10), 2, Random.Range(-10,10));
            GameObject newVestra = Instantiate(vestraPrefab, temp + Self.transform.position, transform.rotation);
            foreach (var VARIABLE in darklings)
            {
                VARIABLE.GetComponent<Health>().Amount -= 10000;
            }
            darklings.Clear();
            AddToKennith(newVestra);
        }


        private void Spawn()
        {
            if (darklings.Count == 30)
            {
                newVestra();
                Self.GetComponent<Energy>().Change(-cost);
                return;
            }
            Vector3 temp = new Vector3(Random.Range(-10,10), 2, Random.Range(-10,10));
            GameObject newDarkling = Instantiate(darklingPrefab, temp + Self.transform.position, transform.rotation);
            newDarkling.GetComponent<Darkling_Model>().vestraLead = Self;
            darklings.Add(newDarkling);
            Self.GetComponent<Energy>().Change(-cost);
            AddToKennith(newDarkling);
        }

        public void AddToKennith(GameObject gameObject)
        {
            _kennithModel = FindObjectsOfType<Kennith_Model>();
            foreach (var Ken in _kennithModel)
            {
                Ken.AddNewEnemy(gameObject);
            }
        }
    }
}
