using System.Collections;
using UnityEngine;
using Utils;

namespace Weapons
{
    public class WeaponInput_AI : BaseWeaponInput
    {
        [SerializeField, MinMax(0, 10)] private MinMax ShootDelayRange;
        [SerializeField, MinMax(0, 10)] private MinMax InitialShootDelayRange; 

        private void OnEnable()
        {
            StartCoroutine(MocShootingRoutine());
        }

        private IEnumerator MocShootingRoutine()
        {
            yield return new WaitForSeconds(InitialShootDelayRange.RandomValue);

            do
            {
                Weapon.DoShoot();
                
                yield return new WaitForSeconds(ShootDelayRange.RandomValue);
            } while (enabled);
        }
    }
}
