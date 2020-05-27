using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    public static class EnumerableUtils
    {
        public static TResult GetRandom<TResult>(this IEnumerable<TResult> self) where TResult : Object
        {
            var selfListed = self.ToList();
            
            if (selfListed.Count == 0)
            {
                Debug.LogWarning("Couldn't get random value from the list. It is empty. Returned null");
                return null;
            }

            var idx = Random.Range(0, selfListed.Count);
            var value = selfListed[idx];
            return value;
        }
    }
}
