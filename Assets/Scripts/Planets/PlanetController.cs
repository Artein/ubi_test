using Damage;
using Health;
using UnityEngine;

namespace Planets
{
    [RequireComponent(typeof(HealthController))]
    public class PlanetController : MonoBehaviour, IPlanetController
    {
        private HealthController _healthController;

        private void Awake()
        {
            _healthController = GetComponent<HealthController>();
        }

        private void OnEnable()
        {
            _healthController.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _healthController.HealthChanged -= OnHealthChanged;
        }

        bool IDamageReceiver.ApplyDamage(IDamageProvider damageProvider)
        {
            if (!enabled)
            {
                return false;
            }

            var healthDiff = _healthController.ChangeHealth(-damageProvider.DamageValue);
            return healthDiff != 0;
        }

        private void OnValidate()
        {
            var healthController = GetComponent<HealthController>();
            if (healthController.Health <= 0)
            {
                Debug.LogWarning($"{name} planet has wrong {healthController.Health} health value. Must be bigger than 0", this);
            }
        }

        private void OnHealthChanged(int currHealth, int prevHealth)
        {
            if (currHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
