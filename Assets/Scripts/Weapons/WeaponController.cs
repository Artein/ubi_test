using System;
using UnityEngine;
using Weapons.Bullets;
using Zenject;

namespace Weapons
{
    public class WeaponController : MonoBehaviour, IWeapon
    {
        [Inject] private WeaponSettings _settings;
        [Inject] private GameObject _bulletPrefab;
        [Inject] private IBulletSpawnTransformProvider _bulletTransformProvider;
        [Inject] private BulletFactory _bulletFactory;

        public DateTime LastShootTime { get; private set; } = DateTime.MinValue;

        private float MillisecondsBetweenShots => 1000f * 60f / _settings.ShootsPerMinute;
        private bool CanShoot => (DateTime.Now - LastShootTime).TotalMilliseconds >= MillisecondsBetweenShots;

        void IWeapon.DoShoot()
        {
            if (!CanShoot)
            {
                return;
            }
            
            LastShootTime = DateTime.Now;
            
            _bulletFactory.Create(_bulletPrefab, _bulletTransformProvider.BulletSpawnPosition, _bulletTransformProvider.BulletSpawnRotation);
        }
    }
}
