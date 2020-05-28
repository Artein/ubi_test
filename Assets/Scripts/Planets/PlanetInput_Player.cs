using UnityEngine;
using Zenject;

namespace Planets
{
    public class PlanetInput_Player : MonoBehaviour, IPlanetInput
    {
        [Inject] public IPlanetPresenter PlanetPresenter { get; }
        
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            UpdateShootDirection();
        }
        
        private void UpdateShootDirection()
        {
            var mousePosW = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var direction = (mousePosW - PlanetPresenter.transform.position).normalized;
            
            PlanetPresenter.UpdateLookAt(direction);
        }
    }
}
