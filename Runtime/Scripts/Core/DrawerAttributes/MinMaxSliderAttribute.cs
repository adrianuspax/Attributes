using System;

namespace ASPax.Attributes.Drawer
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class MinMaxSliderAttribute : DrawerAttribute
    {
        private readonly float _minValue;
        private readonly float _maxValue;

        public MinMaxSliderAttribute(float minValue, float maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public (float min, float max) Value => (_minValue, _maxValue);
    }
}
