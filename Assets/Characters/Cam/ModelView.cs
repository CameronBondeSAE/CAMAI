using System.Collections;
using System.Collections.Generic;
using Cam;
using UnityEngine;

public class ModelView : MonoBehaviour
{
    public AttackState AttackState;
    public AudioSource AudioSource;
    public Renderer Renderer;

    public AudioClip meowClip;

// Start is called before the first frame update
    void Awake()
    {
        AttackState.OnAttack += OnAttack;
    }

    private void OnDestroy()
    {
        AttackState.OnAttack -= OnAttack;
    }
    
    

    private void OnAttack()
    {
        GetComponent<Renderer>().material.color = Color.red;
        AudioSource.clip = meowClip;
        AudioSource.Play();
    }
}