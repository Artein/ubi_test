using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;
using Zenject;

public class PlanetsGenerationSystem : MonoBehaviour
{
    [SerializeField, Min(0)] private int _planetsAmount;
    [SerializeField, Min(0)] private float _generationDistanceMin;
    [SerializeField, Min(0)] private float _generationDistanceMax; // todo: use RangeField
    [SerializeField] private List<PlanetController> _planetPrefabs;
    
    [Inject] private IInstantiator _instantiator;
    [Inject] private ISolarSystemCenterProvider _centerProvider;

    [Inject(Id = SolarSystemInstaller.ID_PlanetsContainer)]
    private Transform _planetsContainer;

    private readonly List<PlanetController> _generatedPlanets = new List<PlanetController>();

    private void Awake()
    {
        Assert.IsTrue(_planetPrefabs.Count > 0);
        for (int i = 0; i < _planetsAmount; i += 1)
        {
            var pos = CalculateNextInitialPosition();
            var prefab = _planetPrefabs.GetRandom();
            var planet = GeneratePlanet(prefab, pos, _planetsContainer);
            _generatedPlanets.Add(planet);
        }
    }

    private PlanetController GeneratePlanet([NotNull] PlanetController planetPrefab, Vector3 position, [NotNull] Transform parent)
    {
        var planet = _instantiator.InstantiatePrefabForComponent<PlanetController>(planetPrefab, position, Quaternion.identity, parent);
        return planet;
    }

    private Vector3 CalculateNextInitialPosition()
    {
        // todo: handle possible initial collision. Keep in mind planet size
        var offset = Random.Range(_generationDistanceMin, _generationDistanceMax);
        var randomRot = Random.rotation;
        var dir = new Vector3(randomRot.x, randomRot.y, 0).normalized;
        var pos = _centerProvider.transform.position + offset * dir;
        return pos;
    }
}
