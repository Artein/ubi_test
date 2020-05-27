using System;
using UnityEngine;

namespace Utils
{
    public class MinMaxAttribute : PropertyAttribute
    {
        public readonly float Min;
        public readonly float Max;

        public MinMaxAttribute(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
    
    [Serializable] public struct MinMax
    {
        [SerializeField] public float Min;
        [SerializeField] public float Max;

        public float RandomValue => UnityEngine.Random.Range(Min, Max);

        public MinMax(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public float Clamp(float value)
        {
            return Mathf.Clamp(value, Min, Max);
        }
    }
}
