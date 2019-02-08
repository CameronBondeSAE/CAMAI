using UnityEngine;

namespace Kennith
{
    public class SpiritBomb : StateBase
    {

        public GameObject spiritBomb;
        private GameObject spawnedSpiritBomb;
        
        public float spiritBombDelay = 5f;

        readonly Vector3 scaleIncrease = new Vector3(0.02f,0.02f,0.02f);
        readonly Vector3 posIncrease = new Vector3(0,0.01f,0);
        
        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Attack Enter", gameObject);

            spawnedSpiritBomb = Instantiate(spiritBomb, transform.position + new Vector3(0,2,0), transform.rotation);
            Invoke("Exit", spiritBombDelay);
            
        }

        public override void Execute()
        {
            base.Execute();
            
            Debug.Log("Attack Execute", gameObject);

            spawnedSpiritBomb.transform.localScale += scaleIncrease;
            spawnedSpiritBomb.transform.position += posIncrease;
        
        }

        public override void Exit()
        {
            base.Exit();
            
            spawnedSpiritBomb.GetComponent<Rigidbody>().velocity = spawnedSpiritBomb.transform.forward * 100;
            
            Debug.Log("Attack Exit", gameObject);
        }
    }

}