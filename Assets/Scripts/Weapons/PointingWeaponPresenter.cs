using UnityEngine;

namespace Weapons
{
    public class PointingWeaponPresenter : MonoBehaviour, IWeaponPresenter
    {
        [SerializeField] private Transform BulletPoint;
        
        public Vector3 BulletSpawnPosition => BulletPoint.transform.position;
        public Quaternion BulletSpawnRotation => transform.rotation;
    }
}
