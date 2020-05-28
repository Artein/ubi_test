using UnityEngine;
using Zenject;

namespace Planets
{
    public class PlanetPresenter : MonoBehaviour
    {
        [Inject] private PlanetController _controller;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _controller.HandleHit();
        }
    }
}
