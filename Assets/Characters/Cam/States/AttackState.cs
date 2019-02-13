using System.Collections;
using UnityEngine;

namespace Cam
{
    public class AttackState : StateBase
    {
        private MrDudes_Model _mrDudesModel;
        public AudioClip meowClip;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _mrDudesModel = GetComponent<MrDudes_Model>();
        }

        public override void Enter()
        {
            base.Enter();

//            Debug.Log("AttackEnter");
            
            GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine("AttackCoroutine");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("AttackUpdate");
        }

        public IEnumerator AttackCoroutine()
        {
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
}
