﻿using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    // todo: must be poolable factory
    [UsedImplicitly]
    public class SimpleBulletFactory : IFactory<Object, Vector3, Quaternion, IBullet>
    {
        private readonly Transform _parent;
        private readonly DiContainer _container;

        public SimpleBulletFactory(DiContainer container, [Inject(Id = WeaponInstaller.ID_BulletsContainer)] Transform parent)
        {
            _parent = parent;
            _container = container;
        }

        public IBullet Create(Object prefab, Vector3 position, Quaternion rotation)
        {
            var bullet = _container.InstantiatePrefabForComponent<IBullet>(prefab, position, rotation, _parent);
            return bullet;
        }
    }
}
