using System.Collections;
using System.Collections.Generic;
using ReGoap.Unity;
using UnityEngine;

public class BuilderAgent : ReGoapAgent<string,object>
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitASec());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CalculateNewGoal(true);
        }
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(2);
        CalculateNewGoal(true);
    }
}
