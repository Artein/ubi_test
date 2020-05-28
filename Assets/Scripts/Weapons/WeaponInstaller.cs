using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;
using Zenject;

namespace Weapons
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private List<WeaponSettings> WeaponSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<WeaponSettings>()
                .FromMethod(GetRandomWeaponSettings)
                .WhenInjectedInto<WeaponController>();

            Container.Bind<IWeapon>()
                .FromComponentInChildren()
                .WhenInjectedInto<IWeaponInput>();
        }

        private WeaponSettings GetRandomWeaponSettings()
        {
            Assert.IsTrue(WeaponSettings.Count > 0);
            var settings = WeaponSettings.GetRandom();
            return settings;
        }
    }
}
