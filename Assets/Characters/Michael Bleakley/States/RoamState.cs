using UnityEngine;

namespace Michael
{
    public class RoamState : StateBase
    {
        [SerializeField]
        private Vector3 destination;
        public int destinationRange;

        public override void Enter()
        {
            destination = new Vector3(Random.Range(-destinationRange, destinationRange),0,Random.Range(-destinationRange, destinationRange));
            destination += transform.position;
            base.Enter();
        }

        public override void Execute()
        {
            base.Execute();
            if (Vector3.Distance(transform.position, destination) < 1) Exit();
            GetComponent<Vestra_Model>().Move(destination);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
