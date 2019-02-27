using System.Collections;
using System.Collections.Generic;
using Cam;
using UnityEngine;

public class ViewModel : MonoBehaviour
{
    public AttackState AttackState;
    public AudioSource AudioSource;
    public Renderer Renderer;

    public AudioClip meowClip;

    public MrDudes_Model mrDudesModel;

    public ParticleSystem particleSystem;

// Start is called before the first frame update
    void Awake()
    {
        AttackState.OnAttack += OnAttack;
        
        mrDudesModel.OnGetBig += OnGetBig;        
    }

    private void OnDestroy()
    {
        AttackState.OnAttack -= OnAttack;
        mrDudesModel.OnGetBig -= OnGetBig;        
    }

    private void OnGetBig()
    {
        AudioSource.clip = meowClip;
        AudioSource.Play();
        ParticleSystem.ShapeModule shapeModule = particleSystem.shape;
        shapeModule.radius = mrDudesModel.getBigHitRadius;
        particleSystem.Emit(1000);
    }

    
    

    private void OnAttack()
    {
        GetComponent<Renderer>().material.color = Color.red;
        AudioSource.clip = meowClip;
        AudioSource.Play();
    }
}