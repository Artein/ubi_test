using System.Collections;
using UnityEngine;
using Utils;
using Zenject;

namespace Weapons
{
    public class WeaponInput_AI : MonoBehaviour, IWeaponInput
    {
        [SerializeField, MinMax(0, 10)] private MinMax ShootDelayRange;
        [SerializeField, MinMax(0, 10)] private MinMax InitialShootDelayRange;

        [Inject] public IWeaponController WeaponController { get; }

        private void OnEnable()
        {
            StartCoroutine(MocShootingRoutine());
        }

        private IEnumerator MocShootingRoutine()
        {
            yield return new WaitForSeconds(InitialShootDelayRange.RandomValue);

            do
            {
                WeaponController.DoShoot();
                
                yield return new WaitForSeconds(ShootDelayRange.RandomValue);
                
            } while (enabled);
        }
    }
}
