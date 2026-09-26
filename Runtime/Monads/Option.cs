using System;

namespace UtilityToolkit.Monads
{
    public readonly struct Option<T>
    {
        public static Option<T> None => default;
        public static Option<T> Some(T value) => new(value);

        private readonly bool _isSome;
        private readonly T _value;

        private Option(T value)
        {
            _value = value;
            _isSome = _value is { };
        }

        public bool IsSome(out T value)
        {
            value = _value;
            return _isSome;
        }

        public void Try(Action<T> action)
        {
            if (IsSome(out T value)) action(value);
        }

        public Option<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            return IsSome(out T value)
                ? Option<TResult>.Some(selector(value))
                : Option<TResult>.None;
        }

        public Option<TResult> FlatSelect<TResult>(Func<T, Option<TResult>> selector)
        {
            return IsSome(out T value)
                ? selector(value)
                : Option<TResult>.None;
        }

        public TResult SelectOrDefault<TResult>(Func<T, TResult> selector, TResult defaultValue = default)
        {
            return IsSome(out T value) ? selector(value) : defaultValue;
        }

        public T GetOrDefault(T defaultValue = default)
        {
            return IsSome(out T value) ? value : defaultValue;
        }
    }
}