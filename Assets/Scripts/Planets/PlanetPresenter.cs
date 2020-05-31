using Damage;
using UnityEngine;
using Zenject;

namespace Planets
{
    public class PlanetPresenter : MonoBehaviour, IPlanetPresenter
    {
        [SerializeField] private float RotationSpeed = 3f;
        
        [Inject] public IPlanetController PlanetController { get; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var damageProvider = collision.gameObject.GetComponent<IDamageProvider>();
            if (damageProvider != null)
            {
                PlanetController.ApplyDamage(damageProvider);
            }
        }

        void IPlanetPresenter.UpdateLookAt(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        }
    }
}
