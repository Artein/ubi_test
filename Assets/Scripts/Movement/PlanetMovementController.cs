using UnityEngine;
using Utils;
using Zenject;
using Random = UnityEngine.Random;

// todo: [optimization] in ECS will be *System
namespace Movement
{
    public class PlanetMovementController : MonoBehaviour
    {
        [SerializeField, MinMax(1, 10)] private MinMax RotationsPerMinuteRange;
    
        private float AngularSpeed => _rotationsPerSecond.Value * 360f;
        private float _currentAngle;
        private Vector2 _ellipseSize;
        private Vector3 _pivotPosition;
        private float? _rotationsPerSecond;

        [Inject]
        private void Construct(Vector3 pivotPosition, Vector2 ellipseSize, [InjectOptional] float? rotationsPerMinute)
        {
            _ellipseSize = ellipseSize;
            _pivotPosition = pivotPosition;

            if (rotationsPerMinute.HasValue)
            {
                _rotationsPerSecond = Mathf.Max(rotationsPerMinute.Value, 0f) / 60f;
            }
        }

        private void Start()
        {
            _currentAngle = Random.Range(0, 360);
            if (!_rotationsPerSecond.HasValue)
            {
                _rotationsPerSecond = RotationsPerMinuteRange.RandomValue / 60f;
            }
        }

        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            _currentAngle = GetNextAngle(_currentAngle, AngularSpeed);
            var currentAngleRad = _currentAngle * Mathf.Deg2Rad;
            var x = Mathf.Sin(currentAngleRad) * _ellipseSize.x;
            var y = Mathf.Cos(currentAngleRad) * _ellipseSize.y;
        
            transform.position = _pivotPosition + new Vector3(x, y, 0);
        }

        private static float GetNextAngle(float currentAngle, float angularSpeed)
        {
            var newAngle = (currentAngle + angularSpeed * Time.deltaTime) % 360f;
            return newAngle;
        }
    }
}
