using System;
using UnityEngine;
using Zenject;

namespace Weapons
{
    public class WeaponController : MonoBehaviour, IWeapon
    {
        [Inject] private WeaponSettings _settings;

        public DateTime LastShootTime { get; private set; } = DateTime.Now;

        private float MillisecondsBetweenShots => 1000f * 60f / _settings.ShootsPerMinute;
        private bool CanShoot => (DateTime.Now - LastShootTime).TotalMilliseconds <= MillisecondsBetweenShots;

        void IWeapon.DoShoot()
        {
            if (!CanShoot)
            {
                return;
            }
            
            LastShootTime = DateTime.Now;
            
            // todo: spawn bullet from prefab
            // todo: must be poolable factory
        }
    }
}
