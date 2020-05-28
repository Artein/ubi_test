using Prefabs.Bullets;
using UnityEngine;
using Zenject;

namespace Weapons.Bullets
{
    public class BulletController : MonoBehaviour, IBullet
    {
        [Inject] private BulletSettings _settings;
    }
}
