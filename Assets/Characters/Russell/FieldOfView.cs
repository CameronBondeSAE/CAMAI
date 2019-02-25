
using System.Collections.Generic;

using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public float radius;
    [UnityEngine.Range(0,360)]
    public float viewAngle;

    public List<Transform> visibleTargets = new List<Transform>();
    
    public Vector3 DirectionAngles(float angleDegree, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleDegree += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleDegree * Mathf.Deg2Rad),0,Mathf.Cos((angleDegree*Mathf.Deg2Rad)));
    }

    public void FindVisibleTargets()
    {        
        visibleTargets.Clear();
        Collider[] charactersICanSee = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < charactersICanSee.Length; i++)
        {
            
            Transform target = charactersICanSee[i].transform;
            CharacterBase cb = target.GetComponent<CharacterBase>();
            if (cb != null && cb != this)
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    RaycastHit hit;
                    float disToTarget = Vector3.Distance(transform.position, target.position);
                    if (Physics.Raycast(transform.position, dirToTarget, out hit, disToTarget))
                    {
                        if (hit.transform == target)
                        {
                            visibleTargets.Add(target);
                        }
                        
                    }

                }
            }


        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
