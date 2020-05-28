using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public interface IBullet
    {
        Transform transform { get; }
    }
    
    [UsedImplicitly]
    public class BulletFactory : PlaceholderFactory<Object, Vector3, Quaternion, IBullet> {}
}
