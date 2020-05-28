using JetBrains.Annotations;
using Movement;
using UnityEngine;
using Zenject;

namespace Planets
{
    [UsedImplicitly]
    public class PlanetInstaller : Installer<PlanetsGenerationSystem, ISolarSystemCenterProvider, PlanetInstaller>
    {
        [Inject] private PlanetsGenerationSystem _planetsGenerationSystem;
        [Inject] private ISolarSystemCenterProvider _centerProvider;
    
        public override void InstallBindings()
        {
            Container.Bind<Vector3>()
                .FromMethod(() => _centerProvider.transform.position)
                .WhenInjectedInto<PlanetMovementController>();

            Container.Bind<Vector2>()
                .FromMethod(() => _planetsGenerationSystem.CalculateRandomOffset())
                .WhenInjectedInto<PlanetMovementController>();

            Container.Bind<PlanetController>()
                .FromComponentInParents()
                .WhenInjectedInto<PlanetPresenter>();
        }
    }
}
