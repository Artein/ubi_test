using UnityEngine;

namespace Weapons
{
    public class PointingWeaponPresenter : MonoBehaviour, IWeaponPresenter
    {
        public Vector3 BulletSpawnPosition => transform.position;
        public Quaternion BulletSpawnRotation => transform.rotation;
    }
}
