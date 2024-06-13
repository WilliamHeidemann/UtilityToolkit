﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace UtilityToolkit.Runtime
{
    public static class CollectionMethods
    {
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            var list = enumerable.ToArray();
            var random = new Random();
            var index = random.Next(list.Length);
            return list[index];
        }

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var random = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
            return list;
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            var list = enumerable.ToList();
            return list.Shuffle();
        }
    }
}