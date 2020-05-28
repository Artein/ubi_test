using UnityEngine;

namespace Planets
{
    public class PlanetController : MonoBehaviour, IPlanetController
    {
        void IPlanetController.HandleHit()
        {
            if (!enabled)
            {
                return;
            }
            
            Destroy(gameObject);
        }
    }
}
