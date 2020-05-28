using UnityEngine;

namespace Weapons
{
    public interface IBulletSpawnTransformProvider
    {
        Vector3 BulletSpawnPosition { get; }
        Vector3 BulletSpawnDirection { get; }
    }
}
