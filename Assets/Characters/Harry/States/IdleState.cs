using UnityEngine;

namespace Kennith
{
    public class IdleState : StateBase
    {
        private Renderer myRenderer;

        private void Start()
        {
            myRenderer = GetComponentInParent<Renderer>();
        }

        public override void Enter()
        {
            Debug.Log("Idle Enter", gameObject);
            StartCoroutine(DelayExit(endDelay));
        }

        public override void Tick()
        {
            Debug.Log("Idle Execute", gameObject);
            myRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        public override void Exit()
        {
            myRenderer.material.color = new Color(1, 1, 1);
            Debug.Log("Idle Exit", gameObject);

            base.Exit();
        }
    }
}