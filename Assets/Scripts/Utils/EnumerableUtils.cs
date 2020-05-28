using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Utils
{
    public static class EnumerableUtils
    {
        [CanBeNull]
        public static TResult GetRandom<TResult>(this IEnumerable<TResult> self) where TResult : Object
        {
            var selfListed = self.ToList();
            if (!TryGetRandom<TResult>(selfListed, out TResult result))
            {
                return null;
            }

            return result;
        }

        // for value types
        public static bool TryGetRandom<TResult>(this IEnumerable<TResult> self, out TResult result)
        {
            var selfListed = self.ToList();
            
            if (selfListed.Count == 0)
            {
                Debug.LogWarning("Couldn't get random value from the list. It is empty. Returned null");
                result = default;
                return false;
            }

            var idx = Random.Range(0, selfListed.Count);
            result = selfListed[idx];
            return true;
        }
    }
}
