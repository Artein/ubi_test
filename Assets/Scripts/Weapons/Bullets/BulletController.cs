using Prefabs.Bullets;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public class BulletController : MonoBehaviour, IBullet
    {
        [Inject] private BulletSettings _settings;

        private bool _isShot;

        public BulletSettings Settings => _settings;

        public event ShootStartingDelegate ShootStarting;

        public void HandleHit()
        {
            if (!enabled)
            {
                return;
            }
            
            Destroy(gameObject);
        }
        
        void IBullet.StartShoot(Vector2 shootDirection)
        {
            if (_isShot)
            {
                return;
            }

            _isShot = true;
            
            ShootStarting?.Invoke(shootDirection);
        }

        public delegate void ShootStartingDelegate(Vector2 shootDirection);
    }
}
