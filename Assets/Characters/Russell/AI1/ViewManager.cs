using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Russell
{
    public class ViewManager : MonoBehaviour
    {
        public GameObject parent;
        public GameObject states;
        public ParticleSystem dashParticleSystem;
        public ParticleSystem deathParticleSystem;
        public ParticleSystem barrageParticleSystem;
        
        // Start is called before the first frame update
        private void Awake()
        {
            parent.GetComponent<Kyllarr_Model>().KillMove += DashAttackView;
            //parent.GetComponent<Kyllarr_Model>().Killme += DeathView;
            states.GetComponent<HoverState>().TargetAquired += BarrageView;
    
        }
    
        private void DeathView()
        {
            //Debug.Log("i ran");
            //deathParticleSystem.Play();
            
        }
    
        private void DashAttackView()
        {
            dashParticleSystem.Play();
            Debug.Log("run you fuck");
            
        }


        private void BarrageView()
        {
            barrageParticleSystem.Play();
        }
    
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }

}

