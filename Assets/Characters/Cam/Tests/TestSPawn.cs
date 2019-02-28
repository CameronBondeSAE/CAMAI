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
    }
}
