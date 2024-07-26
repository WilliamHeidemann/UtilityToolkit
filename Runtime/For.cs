using System;
using System.Collections.Generic;

namespace UtilityToolkit.Runtime
{
    public static class For
    {
        public static void Range(int i, Action action)
        {
            for (int j = 0; j < i; j++)
            {
                action();
            }
        }

        public static void Range(int i, Action<int> action)
        {
            for (int j = 0; j < i; j++)
            {
                action(j);
            }
        }

        public static void NestedRange(int i, int j, Action<int, int> action)
        {
            for (int k = 0; k < i; k++)
            {
                for (int l = 0; l < j; l++)
                {
                    action(k, l);
                }
            }
        }

        public static T[] GetValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)) as T[];
        }

        public static void EachEnum<T>(Action<T> action) where T : Enum
        {
            foreach (var t in GetValues<T>())
            {
                action(t);
            }
        }
    }
}