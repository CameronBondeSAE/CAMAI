using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSPawn : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        Instantiate(prefab);

        Vector3 localTargetOffset = transform.InverseTransformPoint(target);

        if (localTargetOffset.x < 0)
        {
            
        }    // he's to the left of me


            if (localTargetOffset.z > 0)
            {
                
            }    // He's in front of me
            
            //Needed to comment this out cause it wasent finished - Russ
            //Quaternion
    }
}
