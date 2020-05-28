using Planets;
using UnityEngine;
using Utils;
using Zenject;

public class SolarSystemInstaller : MonoInstaller
{
    [SerializeField, RequireInterface(typeof(ISolarSystemCenterProvider))] private Object SolarSystemCenterProvider;
    [SerializeField] private GameObject PlanetsContainer;
    [SerializeField] private PlanetsGenerationSystem PlanetsGenerationSystem;

    public const string ID_PlanetsContainer = "PlanetsContainer";
    
    public override void InstallBindings()
    {
        Container.Bind<PlanetsGenerationSystem>()
            .FromInstance(PlanetsGenerationSystem)
            .AsSingle().NonLazy();

        // todo: introduce interface instead of gameobject with id
        Container.Bind<Transform>()
            .WithId(ID_PlanetsContainer)
            .FromInstance(PlanetsContainer.transform)
            .AsSingle().NonLazy();

        PlanetInstaller.Install(Container, PlanetsGenerationSystem, SolarSystemCenterProvider as ISolarSystemCenterProvider);
    }
}
