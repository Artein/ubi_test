using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "WeaponSettings", menuName = "Orbitality/Weapon Settings")]
    public class WeaponSettings : ScriptableObject
    {
        [SerializeField, Min(0.01f)] private float WeaponShotsPerMinute = 1;

        public float ShootsPerMinute => WeaponShotsPerMinute;
    }
}
