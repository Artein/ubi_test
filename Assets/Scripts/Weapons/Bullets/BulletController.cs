using Damage;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public class BulletController : MonoBehaviour, IBullet
    {
        private bool _isShot;

        [Inject] BulletSettings IBullet.Settings { get; }
        int IDamageProvider.DamageValue => ((IBullet) this).Settings.DamageValue;
        
        public event ShootStartingDelegate ShootStarting;
        
        void IBullet.StartShoot(Vector2 shootDirection)
        {
            if (_isShot)
            {
                return;
            }

            _isShot = true;
            
            ShootStarting?.Invoke(shootDirection);
        }

        bool IDamageReceiver.ApplyDamage(IDamageProvider damageProvider)
        {
            if (!enabled)
            {
                return false;
            }
            
            Destroy(gameObject);
            return true;
        }
    }
}
