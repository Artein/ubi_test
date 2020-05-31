using Damage;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public delegate void ShootStartingDelegate(Vector2 shootDirection);
    
    public interface IBulletController : IDamageProvider, IDamageReceiver
    {
        BulletSettings Settings { get; }
        event ShootStartingDelegate ShootStarting;
        void StartShoot(Vector2 direction);

    }
    
    [UsedImplicitly]
    public class BulletFactory : PlaceholderFactory<Object, Vector3, Quaternion, IBulletController> {}
}
