using System.Collections.Generic;

namespace UtilityToolkit.Runtime
{
    public static class DataStructureConversion
    {
        public static Stack<T> ToStack<T>(this IEnumerable<T> enumerable)
        {
            var stack = new Stack<T>();
            foreach (var element in enumerable)
            {
                stack.Push(element);
            }

            return stack;
        }

        public static Queue<T> ToQueue<T>(this IEnumerable<T> enumerable)
        {
            var queue = new Queue<T>();
            foreach (var element in enumerable)
            {
                queue.Enqueue(element);
            }

            return queue;
        }
    }
}