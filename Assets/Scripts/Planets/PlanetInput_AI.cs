using UnityEngine;
using Zenject;

namespace Planets
{
    public class PlanetInput_AI : MonoBehaviour, IPlanetInput
    {
        [Inject] public IPlanetPresenter PlanetPresenter { get; }
        
        // todo: rotate toward player (closest planet?)
    }
}
