using UnityEngine;

namespace Kennith
{
    public class FleeState : StateBase
    {
        private Kennith_Model model;

        private void Awake()
        {
            model = GetComponentInParent<Kennith_Model>();
        }

        public override void Enter()
        {
            base.Enter();
            // Debug.Log("Flee Enter", gameObject);
            model.transform.Rotate(new Vector3(0,180,0));
            model.ChangeState(model.moveState);
        }

    }

}

