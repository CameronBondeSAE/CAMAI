using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public float ViewDist = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RaycastHit CastRay(Vector3 direction)
    {
        RaycastHit ray;
        Physics.Raycast(gameObject.transform.position, direction, out ray);
        return ray;
    }
    
    public List<CharacterBase> UpdateVision()
    {
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

        return found;
    }
    /*
    public CharacterBase GetClosest()
    {
        List<CharacterBase> order = UpdateVision();
        CharacterBase smallest;
        order.Sort( ,);
        foreach (CharacterBase item in order)
        {
            if (smallest)
            {
                if (Vector3.Distance(gameObject.transform.position, smallest.gameObject.transform.position) >
                    Vector3.Distance(gameObject.transform.position, item.gameObject.transform.position))
                {
                    smallest = item;
                }
            }
            else
            {
                smallest = item;
            }
        }

        return smallest;
    }
    */
}
