using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;
using Zenject;

public class PlanetsGenerationSystem : MonoBehaviour
{
    [SerializeField, Min(0)] private int PlanetsAmount = 1;
    [SerializeField, MinMax(0, 20)] private MinMax GenerationDistanceRange;
    [SerializeField] private List<PlanetController> PlanetPrefabs;
    
    [Inject] private IInstantiator _instantiator;

    [Inject(Id = SolarSystemInstaller.ID_PlanetsContainer)]
    private Transform _planetsContainer;

    private readonly List<PlanetController> _generatedPlanets = new List<PlanetController>();

    public Vector2 CalculateRandomOffset()
    {
        // todo: handle possible initial collision. Keep in mind planet size
        var offset = new Vector2(GenerationDistanceRange.RandomValue, GenerationDistanceRange.RandomValue);
        return offset;
    }

    private void Start()
    {
        Assert.IsTrue(PlanetPrefabs.Count > 0);
        for (int i = 0; i < PlanetsAmount; i += 1)
        {
            var prefab = PlanetPrefabs.GetRandom();
            var planet = GeneratePlanet(prefab, Vector3.zero, _planetsContainer);
            _generatedPlanets.Add(planet);
        }
    }

    private PlanetController GeneratePlanet([NotNull] PlanetController planetPrefab, Vector3 position, [NotNull] Transform parent)
    {
        // todo: use Extenject Factory
        var planet = _instantiator.InstantiatePrefabForComponent<PlanetController>(planetPrefab, position, Quaternion.identity, parent);
        return planet;
    }
}
