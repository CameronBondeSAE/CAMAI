using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Instantiate(vestraPrefab, temp + Self.transform.position, transform.rotation);
            foreach (var VARIABLE in darklings)
            {
                Destroy(VARIABLE);
            }
            darklings.Clear();
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
            darklings.Add(newDarkling);
            Self.GetComponent<Energy>().Change(-cost);
        }
    }
}
