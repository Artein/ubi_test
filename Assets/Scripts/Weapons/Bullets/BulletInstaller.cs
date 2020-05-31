using System.Collections.Generic;
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
            // provides random bullet settings for a single bullet
            Container.Bind<BulletSettings>()
                .FromMethod(GetRandomBulletSettings)
                .WhenInjectedInto<IBulletController>();

            Container.Bind<IBulletController>()
                .FromComponentInParents()
                .WhenInjectedInto<IBulletPresenter>();
        }

        private BulletSettings GetRandomBulletSettings()
        {
            Assert.IsTrue(Settings.Count > 0);
            var bulletSettings = Settings.GetRandom();
            return bulletSettings;
        }
    }
}
