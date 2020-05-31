using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;
using Zenject;

namespace Planets
{
    public class PlanetsGenerationSystem : MonoBehaviour
    {
        [SerializeField, MinMax(0, 10)] private MinMax PlanetsAmountRange;
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

        private void Awake()
        {
            Assert.IsTrue(PlanetPrefabs.Count > 0);
            var planetsAmount = PlanetsAmountRange.RandomValue;
            for (int i = 0; i < planetsAmount; i += 1)
            {
                var prefab = PlanetPrefabs.GetRandom();
                Assert.IsNotNull(prefab, "prefab != null");
                
                var offset = CalculateRandomOffset();
                var position = transform.position + new Vector3(offset.x, offset.y);
                var planet = GeneratePlanet(prefab, position, _planetsContainer);
                _generatedPlanets.Add(planet);
            }
        }

        private PlanetController GeneratePlanet([NotNull] PlanetController planetPrefab, Vector3 position, [NotNull] Transform parent)
        {
            // todo: use Extenject Factory
            var planet = _instantiator.InstantiatePrefabForComponent<PlanetController>(planetPrefab, position, Quaternion.identity, parent);
            return planet;
        }

        private void OnValidate()
        {
            foreach (var planetPrefab in PlanetPrefabs)
            {
                if (planetPrefab == null)
                {
                    Debug.LogError($"{nameof(PlanetPrefabs)} has null prefab", this);
                    break;
                }
            }
        }
    }
}
