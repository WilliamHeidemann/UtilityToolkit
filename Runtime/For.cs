using System;

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
    }
}