using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;
using Weapons.Bullets;
using Zenject;

namespace Weapons
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private List<WeaponSettings> WeaponSettings;
        [SerializeField] private List<GameObject> BulletPrefabs;
        [SerializeField] private GameObject BulletsContainer; // todo: introduce interface

        public const string ID_BulletsContainer = "BulletsContainer";
        
        public override void InstallBindings()
        {
            Container.Bind<WeaponSettings>()
                .FromMethod(GetRandomWeaponSettings)
                .WhenInjectedInto<WeaponController>();

            Container.Bind<IBulletSpawnTransformProvider>()
                .FromComponentInChildren()
                .WhenInjectedInto<WeaponController>();

            Container.Bind<GameObject>()
                .FromMethod(GetRandomBulletPrefab)
                .WhenInjectedInto<WeaponController>();

            Container.Bind<Transform>()
                .WithId(ID_BulletsContainer)
                .FromInstance(BulletsContainer.transform);

            Container.BindFactory<Object, Vector3, Quaternion, IBullet, BulletFactory>()
                .FromFactory<SimpleBulletFactory>();

            Container.Bind<IWeapon>()
                .FromComponentInChildren()
                .WhenInjectedInto<IWeaponInput>();
        }

        private GameObject GetRandomBulletPrefab()
        {
            Assert.IsTrue(BulletPrefabs.Count > 0);
            BulletPrefabs.TryGetRandom(out GameObject bulletPrefab);
            return bulletPrefab;
        }

        private WeaponSettings GetRandomWeaponSettings()
        {
            Assert.IsTrue(WeaponSettings.Count > 0);
            var settings = WeaponSettings.GetRandom();
            return settings;
        }

        private void OnValidate()
        {
            int nullBulletPrefabsCount = 0;
            foreach (var bulletPrefab in BulletPrefabs)
            {
                if (bulletPrefab == null)
                {
                    nullBulletPrefabsCount += 1;
                    continue;
                }

                if (bulletPrefab.GetComponent<IBullet>() == null)
                {
                    Debug.LogWarning($"{bulletPrefab.name} must implement {nameof(IBullet)} interface", this);
                }
            }

            if (nullBulletPrefabsCount > 0)
            {
                Debug.LogWarning($"There are {nullBulletPrefabsCount} null prefabs of bullets", this);
            }
        }
    }
}
