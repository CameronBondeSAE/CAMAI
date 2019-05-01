using UnityEngine;

namespace Kennith
{
    public class IdleState : StateBase
    {
        private Energy energy;
        public float regenSpeedMod = 2.25f;

        private void Start()
        {
            energy = GetComponentInParent<Energy>();
        }

        public override void Enter()
        {
            base.Enter();
            // Debug.Log("Idle Enter", gameObject);
            energy.regenEnergySpeed *= regenSpeedMod;
            StartCoroutine(DelayExit(endDelay));
        }

        public override void Exit()
        {
            // Debug.Log("Idle Exit", gameObject);

            energy.regenEnergySpeed /= regenSpeedMod;
            
            base.Exit();
        }
    }
}