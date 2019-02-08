using UnityEngine;

namespace Kennith
{
    public class IdleState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Idle Enter", gameObject);
            Invoke("Exit", 2f);
            
        }

        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("Idle Execute", gameObject);
            GetComponent<Renderer>().material.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
        }

        public override void Exit()
        {
            base.Exit();
            GetComponent<Renderer>().material.color = new Color(1,1,1);
            Debug.Log("Idle Exit", gameObject);
        }
    }

}

