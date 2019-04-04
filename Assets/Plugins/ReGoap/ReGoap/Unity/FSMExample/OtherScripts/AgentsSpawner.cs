using UnityEngine;

namespace ReGoap.Unity.FSMExample.OtherScripts
{
    public class AgentsSpawner : MonoBehaviour
    {
        public int BuildersCount;
        private int spawnedBuilders;
        public GameObject BuilderPrefab;

        public float DelayBetweenSpawns = 0.1f;
        public int AgentsPerSpawn = 100;
        private float spawnCooldown;

        public bool parentToThis = false;
        
        void Awake()
        {
        }

        void Update()
        {
            if (Time.time >= spawnCooldown && spawnedBuilders < BuildersCount)
            {
                spawnCooldown = Time.time + DelayBetweenSpawns;
                for (int i = 0; i < AgentsPerSpawn && spawnedBuilders < BuildersCount; i++)
                {
                    var gameObj = Instantiate(BuilderPrefab);
                    if(parentToThis) gameObj.transform.SetParent(transform);

                    spawnedBuilders++;
                }
            }
        }
    }
}
