using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelview : MonoBehaviour
{
    public PlatoBehaviour reference;
    public Material normal;
    public Material attacking;
    public Material hurt;
    // Start is called before the first frame update
    void Start()
    {
        reference = gameObject.GetComponent<PlatoBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
