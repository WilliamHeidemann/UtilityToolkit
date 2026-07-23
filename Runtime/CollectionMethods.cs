using System;
using System.Collections.Generic;

public static class CollectionMethods
{
    public static T RandomElement<T>(this IList<T> list)
    {
        Random random = new();
        int index = random.Next(list.Count);
        return list[index];
    }

    public static T RandomElement<T>(this T[] array)
    {
        Random random = new();
        int index = random.Next(array.Length);
        return array[index];
    }

    public static IList<T> Shuffle<T>(this IList<T> list)
    {
        Random random = new();
            
        int n = list.Count;
            
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
            
        return list;
    }

    public static T[] Shuffle<T>(this T[] array)
    { 
        Random random = new();
            
        int n = array.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (array[i], array[j]) = (array[j], array[i]);
        }

        return array;
    }
        
    public delegate bool TryGet<in T1, T2>(T1 item, out T2 value);

    public static IEnumerable<T2> TrySelect<T1, T2>(
        this IEnumerable<T1> enumerable, TryGet<T1, T2> tryGet)
    {
        foreach (T1 item in enumerable)
        {
            if (tryGet(item, out T2 result))
            {
                yield return result;
            }
        }
    }
    
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

    public static Option<T> FirstOption<T>(this IEnumerable<T> enumerable)
    {
        foreach (T t in enumerable)
        {
            return Option<T>.Some(t);
        }

        return Option<T>.None;
    }

    public static Option<T> FirstOption<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
    {
        foreach (T t in enumerable)
        {
            if (predicate(t))
                return Option<T>.Some(t);
        }

        return Option<T>.None;
    }

    public static Option<T> LastOption<T>(this IEnumerable<T> enumerable)
    {
        bool found = false;
        T last = default;
        foreach (T t in enumerable)
        {
            found = true;
            last = t;
        }

        return found ? Option<T>.Some(last) : Option<T>.None;
    }

    public static Option<T> LastOption<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
    {
        bool found = false;
        T last = default;
        foreach (T t in enumerable)
        {
            if (predicate(t))
            {
                found = true;
                last = t;
            }
        }

        return found ? Option<T>.Some(last) : Option<T>.None;
    }
}