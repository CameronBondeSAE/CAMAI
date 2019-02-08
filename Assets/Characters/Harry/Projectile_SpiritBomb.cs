using UnityEngine;

namespace Kennith
{
    
    public class Projectile_SpiritBomb : MonoBehaviour
    {
        private void Start()
        {
            Destroy(this.gameObject, 15f);
        }
    }

}

