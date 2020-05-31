using Damage;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public class BulletController : MonoBehaviour, IBulletController
    {
        private bool _isShot;

        [Inject] BulletSettings IBulletController.Settings { get; }
        int IDamageProvider.DamageValue => ((IBulletController) this).Settings.DamageValue;
        
        public event ShootStartingDelegate ShootStarting;
        
        void IBulletController.StartShoot(Vector2 shootDirection)
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
