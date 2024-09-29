using System;
using System.Collections.Generic;

namespace UtilityToolkit.Runtime
{
    public static class For
    {
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