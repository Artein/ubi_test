using System.Collections.Generic;
using Prefabs.Bullets;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;
using Zenject;

namespace Weapons.Bullets
{
    public class BulletInstaller : MonoInstaller
    {
        [SerializeField] private List<BulletSettings> Settings;
        
        public override void InstallBindings()
        {
            Container.Bind<BulletSettings>()
                .FromMethod(GetRandomBulletSettings)
                .WhenInjectedInto<BulletController>();

            Container.Bind<BulletController>()
                .FromComponentInParents()
                .WhenInjectedInto<BulletPresenter>();
        }

        private BulletSettings GetRandomBulletSettings()
        {
            Assert.IsTrue(Settings.Count > 0);
            var bulletSettings = Settings.GetRandom();
            return bulletSettings;
        }
    }
}
