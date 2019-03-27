using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float ViewDist = 10;

    public Queue<CharacterBase> visible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float castray()
    {
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, gameObject.transform.forward*2, out hit);
        return hit.distance;
    }

    public void UpdateVision()
    {
        visible.Clear();
        List<CharacterBase> found = new List<CharacterBase>();
        RaycastHit ray;
        foreach (CharacterBase item in GameManager.Instance.CharacterBases)
        {
            if (item.gameObject != gameObject)
            {
                if (Physics.Raycast(gameObject.transform.position, (item.gameObject.transform.position - gameObject.transform.position).normalized*ViewDist, out ray))
                {
                    if (ray.collider.gameObject == item.gameObject)
                    {
                        found.Add(item);
                    }
                }
            }
        }
        //found.Sort();
        found = found.OrderBy(o => Vector3.Distance(o.transform.position, transform.position)).ToList();
        foreach (CharacterBase item in found)
        {
            visible.Enqueue(item);
        }
    }
}
