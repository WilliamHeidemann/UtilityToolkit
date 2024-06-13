using System;

namespace UtilityToolkit.Runtime
{
    public class Observable<T>
    {
        private T value;
        public event Action<T> OnValueChanged;

        public T Value
        {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                this.value = value;
                OnValueChanged?.Invoke(this.value);
            }
        }

        public Observable(T initialValue = default)
        {
            value = initialValue;
        }
    }
}