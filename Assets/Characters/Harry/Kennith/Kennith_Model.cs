using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kennith
{
    
    public class Kennith_Model : CharacterBase
    {
        [HideInInspector]
        public StateBase spiritBombState, moveState, fleeState, idleState, deathState, hailState, syphonState;
        
        public StateBase currentState;
        
        public double visionRange;
        public double visionAngle;

        public GameObject TargetObject;
        public bool targetVisible = false;
        public float turningDistance;

        public delegate void OnSpiritBomb(GameObject bomb);
        public static OnSpiritBomb ShareYourPower;

        public List<GameObject> enemies = new List<GameObject>();
        public List<Spawner> spawners = new List<Spawner>();

        public void ChangeState(StateBase newState)
        {
            if (currentState == deathState) return;
            
            newState.Enter();
            currentState = newState;

        }

        private void Awake()
        {
            spiritBombState = GetComponentInChildren<SpiritBomb>();
            moveState = GetComponentInChildren<MoveState>();
            fleeState = GetComponentInChildren<FleeState>();
            idleState = GetComponentInChildren<IdleState>();
            deathState = GetComponentInChildren<DeathState>();
            hailState = GetComponentInChildren<HailAttack>();
            syphonState = GetComponentInChildren<PowerSyphonState>();
            
            currentState = moveState;
            currentState.Enter();

            CharacterBase[] characters = FindObjectsOfType<CharacterBase>();

            foreach (CharacterBase c in characters)
            {
                if (c.gameObject.GetComponent<Kennith_Model>() != null) continue;

                if (c.GetComponent<Health>() == null) return;
                
                c.GetComponentInChildren<Health>().OnDeathEvent += RemoveEnemy;
                enemies.Add(c.gameObject);
            }

            spawners.AddRange(FindObjectsOfType<Spawner>());

            foreach (Spawner s in spawners)
            {
                s.OnSpawnedNewGameObject += AddNewEnemy;
            }
            
            GetComponent<Health>().OnDeathEvent += Perish;
            ShareYourPower += SyphoningPower;
        }


        private void Update()
        {
            currentState.Tick();
            
            //TESTING
            if (TargetObject == null) FindTarget();
        }
        
        public void SyphoningPower(GameObject bomb)
        {
            TargetObject = bomb;
            ChangeState(syphonState);   
        }

        public void InvokeShareYourPower(GameObject bomb)
        {
            ShareYourPower?.Invoke(bomb);
        }
                
        public bool CheckFor(GameObject other) // returns true/false if object inserted is visible
        {
            float magnitudeTo = Vector3.Distance(transform.position, other.transform.position);
            
            if (magnitudeTo > visionRange) return false;

            Vector3 targetDir = other.transform.position - transform.position; // correcting object's location relative to us
            if (Vector3.Angle(targetDir, transform.forward) > (visionAngle / 2)) return false;

            return CheckBounds(other);

        }

        private bool ThrowRay(GameObject obj, Collider col, float x, float y, float z)
        {
            Vector3 v;
            RaycastHit hit;
            bool b = false;
            
            v = obj.transform.TransformPoint(x, y, z);
            v = col.ClosestPoint(v);
            if (Physics.Linecast(transform.position + Vector3.up * 2, v, out hit) && hit.transform.gameObject == obj)
            {
                b = true;
            }

            return b;
        }
        
        private bool CheckBounds(GameObject other)
        {
            Collider col = other.GetComponent<Collider>();
            Vector3 ext = col.bounds.extents;

            if (col == null) return false;

            bool r1 = false, r2 = false, r3 = false, r4 = false, r5 = false, r6 = false, r7 = false, r8 = false, r9 = false;

            // checking all corners of a collider + its centre 
            r1 = ThrowRay(other, col, 0,0,0);
            r2 = ThrowRay(other, col, ext.x, ext.y, ext.z);
            r3 = ThrowRay(other, col, -ext.x, ext.y, ext.z);
            r4 = ThrowRay(other, col, ext.x, -ext.y, -ext.z);
            r5 = ThrowRay(other, col, -ext.x, -ext.y, -ext.z);
            r6 = ThrowRay(other, col, ext.x, ext.y, ext.z);
            r7 = ThrowRay(other, col, ext.x, ext.y, -ext.z);
            r8 = ThrowRay(other, col, -ext.x, -ext.y, ext.z);
            r9 = ThrowRay(other, col, -ext.x, -ext.y, -ext.z);

            if (r1 || r2 || r3 || r4 || r5 || r6 || r7 || r8 || r9)
            {
                return true;
            }

            return false;
        }

        public void LookAt(GameObject g, float rotationSpeed)
        {
            if (g == null) return;
            Vector3 lookPos = g.transform.position - transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed);
        }

        public void AddNewEnemy(GameObject g)
        {
            if (g.GetComponent<Kennith_Model>() != null) return;
            
            enemies.Add(g);
            g.GetComponentInChildren<Health>().OnDeathEvent += RemoveEnemy;

        }

        public void RemoveEnemy()
        {
            foreach (GameObject e in enemies)
            {
                if (e == null)
                    enemies.Remove(e);
            }
        }
        
        public void FindTarget()
        {
            List<GameObject> visible = new List<GameObject>();
            
            foreach (GameObject e in enemies)
            {
                if (CheckFor(e))
                    visible.Add(e);
            }

            if (visible.Count <= 0)
            {
                currentState.Exit();
                return;
            }
            
            TargetObject = visible[Random.Range(0, visible.Count - 1)];
            targetVisible = true;
            StartCoroutine(CheckTarget());
            currentState.Exit();
        }
        
        public IEnumerator CheckTarget()
        {
            while (targetVisible)
            {
                yield return new WaitForSeconds(0.34f);

                if (!CheckFor(TargetObject))
                {
                    targetVisible = false;
                    currentState.Exit();
                }
            }

            yield return null;
        }
        
        public void Perish()
        {
           OnDeath();
           ChangeState(deathState);
        }

        private void OnDeath()
        {
            ShareYourPower -= SyphoningPower;

            foreach (GameObject e in enemies)
            {
                e.GetComponentInChildren<Health>().OnDeathEvent -= RemoveEnemy;
            }
            
            foreach (Spawner s in spawners)
            {
                s.OnSpawnedNewGameObject -= AddNewEnemy;
            }
        }
    }
    
}

