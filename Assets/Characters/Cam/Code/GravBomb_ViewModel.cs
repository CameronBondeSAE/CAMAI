using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravBomb_ViewModel : MonoBehaviour
{
    public GravBomb gravBomb;

    private void Start()
    {
        gravBomb.OnGravBomb += OnGravBomb;
    }

    private void OnGravBomb()
    {
        GetComponent<ParticleSystem>().Play();
    }

}
