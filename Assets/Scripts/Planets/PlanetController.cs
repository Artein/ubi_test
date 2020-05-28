using UnityEngine;

namespace Planets
{
    public class PlanetController : MonoBehaviour
    {
        public void HandleHit()
        {
            if (!enabled)
            {
                return;
            }
            
            Destroy(gameObject);
        }
    }
}
