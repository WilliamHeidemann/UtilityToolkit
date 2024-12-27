using System;
using UnityEngine;

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
        
        public static implicit operator Observable<T>(T value) => new(value);

        public static T operator +(Observable<T> a, T b)
        {
            if (a.Value is int i && b is int iValue)
            {
                a.Value = (T)Convert.ChangeType(i + iValue, typeof(T));
                return a.Value;
            }

            if (a.Value is float f && b is float fValue)
            {
                a.Value = (T)Convert.ChangeType(f + fValue, typeof(T));
                return a.Value;
            }
            
            if (a.Value is Percent p && b is Percent pValue)
            {
                a.Value = (T)Convert.ChangeType(p + pValue, typeof(T));
                return a.Value;
            }
            
            Debug.LogWarning($"+ operator not supported in {typeof(T)}. Value not changed");
            return a.Value;
        }

        public static T operator -(Observable<T> a, T b)
        {
            if (a.Value is int i && b is int iValue)
            {
                a.Value = (T)Convert.ChangeType(i - iValue, typeof(T));
                return a.Value;
            }

            if (a.Value is float f && b is float fValue)
            {
                a.Value = (T)Convert.ChangeType(f - fValue, typeof(T));
                return a.Value;
            }
            
            if (a.Value is Percent p && b is Percent pValue)
            {
                a.Value = (T)Convert.ChangeType(p - pValue, typeof(T));
                return a.Value;
            }

            Debug.LogWarning($"- operator not supported in {typeof(T)}. Value not changed");
            return a.Value;
        }
    }
}