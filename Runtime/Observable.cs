using System;

namespace UtilityToolkit.Runtime
{
    public class Observable<T>
    {
        private T _value;
        public event Action<T> OnValueChanged;

        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value)) return;
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }

        public Observable(T initialValue = default)
        {
            _value = initialValue;
        }
        
        public static T operator +(Observable<T> a, T b)
        {
            if (a.Value is int i && b is int j)
            {
                a.Value = (T) Convert.ChangeType(i + j, typeof(T));
                return a.Value;
            }
            if (a.Value is float f && b is float g)
            {
                a.Value = (T) Convert.ChangeType(f + g, typeof(T));
                return a.Value;
            }
            
            a.Value = b;
            return a.Value;
        }
        
        public static T operator -(Observable<T> a, T b)
        {
            if (a.Value is int i && b is int j)
            {
                a.Value = (T) Convert.ChangeType(i - j, typeof(T));
                return a.Value;
            }
            if (a.Value is float f && b is float g)
            {
                a.Value = (T) Convert.ChangeType(f - g, typeof(T));
                return a.Value;
            }
            
            a.Value = b;
            return a.Value;
        }
    }
}