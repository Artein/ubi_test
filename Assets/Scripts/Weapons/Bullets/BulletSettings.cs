using UnityEngine;

namespace Prefabs.Bullets
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "Orbitality/Bullet Settings")]
    public class BulletSettings : ScriptableObject
    {
        [SerializeField, Min(0)] private float Damage;
        [SerializeField, Min(0)] private float Acceleration;
        [SerializeField, Min(0)] private float Mass;

        public float DamageValue => Damage;
        public float AccelerationValue => Acceleration;
        public float MassValue => Mass;
    }
}
