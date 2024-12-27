using UnityEngine;

namespace UtilityToolkit.Runtime
{
    public struct Percent
    {
        private float _value;

        /// <summary>
        /// <returns>A value between 0f and 100f</returns>
        /// </summary>
        public float Value
        {
            get => _value;
            set => _value = Mathf.Clamp(value, 0f, 100f);
        }

        public Percent(float initialValue)
        {
            _value = Mathf.Clamp(initialValue, 0f, 100f);
        }

        public bool IsZero => Mathf.Approximately(Value, 0f);
        public bool IsMax => Mathf.Approximately(Value, 100f);

        public static Percent Zero => new(0);
        public static Percent Max => new(100);

        public static implicit operator float(Percent percent) => percent.Value;
        public static implicit operator Percent(float value) => new(value);
        public static implicit operator int(Percent percent) => (int)percent.Value;
        public static implicit operator Percent(int value) => new(value);

        public static Percent operator +(Percent a, float b)
        {
            a.Value += b;
            return a;
        }

        public static Percent operator -(Percent a, float b)
        {
            a.Value -= b;
            return a;
        }

        public static Percent operator *(Percent a, float b)
        {
            a.Value *= b;
            return a;
        }

        public static Percent operator /(Percent a, float b)
        {
            if (Mathf.Approximately(b, 0f))
            {
                return a;
            }

            a.Value /= b;
            return a;
        }

        public static bool operator <(Percent a, float b) => a.Value < b;
        public static bool operator >(Percent a, float b) => a.Value > b;
        public static bool operator <=(Percent a, float b) => a.Value <= b;
        public static bool operator >=(Percent a, float b) => a.Value >= b;
        public static bool operator ==(Percent a, float b) => Mathf.Approximately(a.Value, b);
        public static bool operator !=(Percent a, float b) => !Mathf.Approximately(a.Value, b);

        public static Percent operator +(Percent a, Percent b)
        {
            a.Value += b.Value;
            return a;
        }

        public static Percent operator -(Percent a, Percent b)
        {
            a.Value -= b.Value;
            return a;
        }

        public static Percent operator *(Percent a, Percent b)
        {
            a.Value *= b.Value;
            return a;
        }

        public static Percent operator /(Percent a, Percent b)
        {
            if (Mathf.Approximately(b.Value, 0f))
            {
                return a;
            }

            a.Value /= b.Value;
            return a;
        }

        public static bool operator <(Percent a, Percent b) => a.Value < b.Value;
        public static bool operator >(Percent a, Percent b) => a.Value > b.Value;
        public static bool operator <=(Percent a, Percent b) => a.Value <= b.Value;
        public static bool operator >=(Percent a, Percent b) => a.Value >= b.Value;
        public static bool operator ==(Percent a, Percent b) => Mathf.Approximately(a.Value, b.Value);
        public static bool operator !=(Percent a, Percent b) => !Mathf.Approximately(a.Value, b.Value);

        public override string ToString() => $"{_value}%";
        public override bool Equals(object obj) => obj is Percent other && this == other;
        public override int GetHashCode() => Value.GetHashCode();
        public bool Equals(Percent other) => this == other;
    }
}