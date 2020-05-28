using UnityEngine;

namespace Weapons
{
    public interface IWeaponPresenter : IBulletSpawnTransformProvider
    {
        Transform transform { get; }
    }
}
