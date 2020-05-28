using UnityEngine;

namespace Planets
{
    public interface IPlanetPresenter
    {
        IPlanetController PlanetController { get; }
        Transform transform { get; }

        void UpdateLookAt(Vector3 direction);
    }
}
