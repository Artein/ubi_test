using JetBrains.Annotations;
using UnityEngine;
using Utils;
using Zenject;

public class SolarSystemInstaller : MonoInstaller
{
    [SerializeField, RequireInterface(typeof(ISolarSystemCenterProvider))] private Object _solarSystemCenterProvider;
    [SerializeField, NotNull] private GameObject _planetsContainer;

    public const string ID_PlanetsContainer = "PlanetsContainer";
    
    public override void InstallBindings()
    {
        Container.Bind<ISolarSystemCenterProvider>()
            .FromInstance(_solarSystemCenterProvider as ISolarSystemCenterProvider)
            .AsSingle().NonLazy();

        // todo: introduce interface instead of gameobject with id
        Container.Bind<Transform>()
            .WithId(ID_PlanetsContainer)
            .FromInstance(_planetsContainer.transform)
            .AsSingle().NonLazy();
    }
}
