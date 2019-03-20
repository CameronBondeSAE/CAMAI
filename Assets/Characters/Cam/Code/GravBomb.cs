using System;
using System.Collections;
using System.Collections.Generic;
using Cam;
using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class GravBomb : MonoBehaviour
{
    Neighbours neighbours;
    public event Action OnGravBomb;

    public enum States
    {
        idle,
        active,
        finished
    }

    public States state;
    public float force = 1000;

    private void Awake()
    {
        neighbours = GetComponent<Neighbours>();
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        OnGravBomb?.Invoke();
        state = States.active;

        while (state == States.active)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            foreach (var rb in neighbours.Rigidbodies)
            {
                if (rb != null)
                {
                    rb.AddForce((rb.position - transform.position) * force, ForceMode.Acceleration);
                }
                
            }                    
            yield return new WaitForEndOfFrame();
        }
    }

}
