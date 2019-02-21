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

    public float castray()
    {
        RaycastHit hit;
        Physics.Raycast(gameObject.transform.position, gameObject.transform.forward*2, out hit);
        return hit.distance;
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
}
