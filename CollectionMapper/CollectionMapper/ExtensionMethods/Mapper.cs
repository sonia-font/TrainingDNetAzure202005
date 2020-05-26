using CollectionMapper.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionMapper.ExtensionMethods
{
    public static class Mapper
    {
        public static IEnumerable<T2> MapCollection<T1, T2>(this IEnumerable<T1> first, Func<T1, T2> second)
        {
            foreach (var item in first)
            {
                yield return second(item);
            }                
        }
    }
}
