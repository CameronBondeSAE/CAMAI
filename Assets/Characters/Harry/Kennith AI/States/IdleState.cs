using UnityEngine;

namespace Kennith
{
    public class IdleState : StateBase
    {
        private Energy energy;
        private float regenSpeed;
        public float regenSpeedMod = 2.25f;

        private void Start()
        {
            energy = GetComponentInParent<Energy>();
        }

        public override void Enter()
        {
            base.Enter();
            // Debug.Log("Idle Enter", gameObject);
            regenSpeed = energy.regenEnergySpeed;
            energy.regenEnergySpeed = regenSpeedMod;
            StartCoroutine(DelayExit(endDelay));
        }

        public override void Exit()
        {
            // Debug.Log("Idle Exit", gameObject);

            energy.regenEnergySpeed = regenSpeed;
            
            base.Exit();
        }
    }
}