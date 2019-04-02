using System;

namespace HiFramework
{
    public struct HiFloat
    {
        private const int Length = 7;
        private float _value;

        public float Value
        {
            get { return _value; }
        }

        private HiFloat(float value)
        {
            _value = (float) Math.Round(value, Length);
        }

        public static implicit operator HiFloat(float value)
        {
            return new HiFloat(value);
        }

        public static implicit operator float(HiFloat value)
        {
            return value._value;
        }

        public static HiFloat operator ++(HiFloat value)
        {
            return ++value._value;
        }

        public static HiFloat operator --(HiFloat value)
        {
            return --value._value;
        }
    }
}