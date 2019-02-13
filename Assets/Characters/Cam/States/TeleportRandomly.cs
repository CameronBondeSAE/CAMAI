using System.Collections;
using System.Collections.Generic;
using Cam;
using UnityEngine;

public class TeleportRandomly : StateBase
{
    private MrDudes_Model _mrDudesModel;
    public AudioClip meowClip;
    private Transform _transform;
    public float teleportRange;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _transform = GetComponent<Transform>();
        _mrDudesModel = GetComponent<MrDudes_Model>();
    }

    public override void Enter()
    {
        base.Enter();

//            Debug.Log("AttackEnter");
            
        GetComponent<Renderer>().material.color = Color.green;
        StartCoroutine("AttackCoroutine");
    }

    public override void Execute()
    {
        base.Execute();
        Debug.Log("AttackUpdate");
    }

    public IEnumerator AttackCoroutine()
    {
        _transform.position = _transform.position + new Vector3(Random.Range(-teleportRange, teleportRange), 0, Random.Range(-teleportRange, teleportRange));
        _audioSource.clip = meowClip;
        _audioSource.Play();
            
        yield return new WaitForSeconds(2);
        _mrDudesModel.EndState();
    }

    public override void Exit()
    {
        base.Exit();
        //          Debug.Log("AttackExit");
        GetComponent<Renderer>().material.color = Color.white;
    }

}
