using JetBrains.Annotations;
using UnityEngine;
using Utils;
using Zenject;

public class SolarSystemInstaller : MonoInstaller
{
    [SerializeField, RequireInterface(typeof(ISolarSystemCenterProvider))] private Object _solarSystemCenterProvider;
    [SerializeField, NotNull] private GameObject _planetsContainer;
    [SerializeField, NotNull] private PlanetsGenerationSystem _planetsGenerationSystem;

    public const string ID_PlanetsContainer = "PlanetsContainer";
    
    public override void InstallBindings()
    {
        Container.Bind<PlanetsGenerationSystem>()
            .FromInstance(_planetsGenerationSystem)
            .AsSingle().NonLazy();

        // todo: introduce interface instead of gameobject with id
        Container.Bind<Transform>()
            .WithId(ID_PlanetsContainer)
            .FromInstance(_planetsContainer.transform)
            .AsSingle().NonLazy();

        PlanetInstaller.Install(Container, _planetsGenerationSystem, _solarSystemCenterProvider as ISolarSystemCenterProvider);
    }
}
