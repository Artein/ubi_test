using UnityEngine;
using Zenject;

namespace Weapons
{
    public abstract class BaseWeaponInput : MonoBehaviour, IWeaponInput
    {
        public IWeapon Weapon { get; private set; }

        [Inject]
        private void Construct(IWeapon weapon)
        {
            Weapon = weapon;
        }
    }
}
