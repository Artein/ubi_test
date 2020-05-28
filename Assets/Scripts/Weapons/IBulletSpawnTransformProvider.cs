using UnityEngine;

namespace Weapons
{
    public interface IBulletSpawnTransformProvider
    {
        Vector3 BulletSpawnPosition { get; }
        Quaternion BulletSpawnRotation { get; }
    }
}
