using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

// todo: [optimization] in ECS will be *System
public class PlanetMovementController : MonoBehaviour
{
    [SerializeField, Min(0)] private float RotationsPerMinuteMin = 1f;
    [SerializeField, Min(0)] private float RotationsPerMinuteMax = 10f;
    
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
            _rotationsPerSecond = Random.Range(RotationsPerMinuteMin, RotationsPerMinuteMax) / 60f;
        }
    }

    private void FixedUpdate()
    {
        UpdatePosition_Fixed();
    }

    private void UpdatePosition_Fixed()
    {
        _currentAngle = GetNextAngle(_currentAngle, AngularSpeed);
        var currentAngleRad = _currentAngle * Mathf.Deg2Rad;
        var x = Mathf.Sin(currentAngleRad) * _ellipseSize.x;
        var y = Mathf.Cos(currentAngleRad) * _ellipseSize.y;
        
        transform.position = _pivotPosition + new Vector3(x, y, 0);
    }

    private float GetNextAngle(float currentAngle, float angularSpeed)
    {
        var newAngle = (currentAngle + angularSpeed) % 360f;
        return newAngle;
    }
}
