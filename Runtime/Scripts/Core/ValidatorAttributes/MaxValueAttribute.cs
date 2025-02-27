using System;

namespace ASPax.Attributes.Validator
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class MaxValueAttribute : ValidatorAttribute
    {
        private readonly float _maxValue;

        public MaxValueAttribute(float maxValue)
        {
            _maxValue = maxValue;
        }

        public MaxValueAttribute(int maxValue)
        {
            _maxValue = maxValue;
        }

        public float MaxValue => _maxValue;
    }
}
