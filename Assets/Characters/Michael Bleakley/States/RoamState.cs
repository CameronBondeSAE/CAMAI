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
            //destination += Self.transform.position;
            base.Enter();
            Debug.Log("Testing entry on roam");
        }

        public override void Execute()
        {
            base.Execute();
            if (Vector3.Distance(transform.position, destination) < 1) Exit();
            Self.GetComponent<Vestra_Model>().Move(destination + Self.transform.position);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
