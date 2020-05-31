using Damage;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Weapons.Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletPresenter : MonoBehaviour, IBulletPresenter, IDamageProvider
    {
        [Inject] private IBulletController _controller;

        int IDamageProvider.DamageValue => _controller.DamageValue;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.mass = _controller.Settings.MassValue;
        }

        private void OnEnable()
        {
            _controller.ShootStarting += OnShootStarting;
        }

        private void OnDisable()
        {
            _controller.ShootStarting -= OnShootStarting;
        }

        private void OnShootStarting(Vector2 shootDirection)
        {
            Assert.IsTrue(shootDirection.magnitude < 1f || Mathf.Approximately(shootDirection.magnitude, 1f), $"{shootDirection} is not normalized");
            var force = shootDirection * _controller.Settings.AccelerationValue;
            _rigidbody.AddForce(force);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _controller.ApplyDamage(null);
        }
    }
}
