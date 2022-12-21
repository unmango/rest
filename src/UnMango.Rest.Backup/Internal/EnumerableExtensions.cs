using System.Collections.Generic;
using System.Linq;

namespace UnMango.Rest.Internal
{
    internal static class EnumerableExtensions
    {
        public static Dictionary<T1, T2> ToDictionary<T1, T2>(this IEnumerable<KeyValuePair<T1, T2>> enumerable)
        {
            return enumerable.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
