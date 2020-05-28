using UnityEngine;

namespace Weapons
{
    public class WeaponInput_Player : BaseWeaponInput
    {
        private void Update()
        {
            // todo: handle rotation and fire here
            // todo: use new Input system
            if (Input.GetMouseButtonDown(0)) // primary button
            {
                Weapon.DoShoot();
            }
        }
    }
}
