using UnityEngine;

namespace Health
{
    public class HealthController : MonoBehaviour, IHealthProvider
    {
        [SerializeField, Min(0)] private int InitialHealth;
        
        public int Health { get; private set; }

        public event HealthChangedDelegate HealthChanged;

        public int ChangeHealth(int value)
        {
            var prevHealth = Health;
            var calculatingHealth = checked(Health + value);
            Health = Mathf.Max(calculatingHealth, 0);

            if (prevHealth == Health)
            {
                return 0;
            }
            
            HealthChanged?.Invoke(Health, prevHealth);

            var changeDiff = Health - prevHealth;
            return changeDiff;
        }

        private void Awake()
        {
            Health = InitialHealth;
        }
    }
}
