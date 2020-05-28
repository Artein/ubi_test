using UnityEngine;
using Zenject;

namespace Weapons
{
    public class WeaponInput_Player : MonoBehaviour, IWeaponInput
    {
        [Inject] public IWeaponController WeaponController { get; }

        private void LateUpdate()
        {
            TryHandleShoot();
        }

        private void TryHandleShoot()
        {
            // todo: use new Input system
            if (Input.GetMouseButtonDown(0)) // primary button
            {
                WeaponController.DoShoot();
            }
        }
    }
}
