using System;

namespace ASPax.Attributes.Validator
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class MinValueAttribute : ValidatorAttribute
    {
        private readonly float _minValue;

        public MinValueAttribute(float minValue)
        {
            _minValue = minValue;
        }

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
        }

        public float MinValue => _minValue;
    }
}
