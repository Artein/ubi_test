using Damage;
using UnityEngine;

namespace Weapons.Bullets
{
    public class BulletController : MonoBehaviour, IBulletController
    {
        [SerializeField] private BulletSettings Settings;
        
        private bool _isShot;

        BulletSettings IBulletController.Settings => Settings;
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
