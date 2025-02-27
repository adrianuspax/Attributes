using System;
using UnityEngine;

namespace ASPax.Attributes.Drawer
{
    using ASPax.Attributes.Utility;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class CurveRangeAttribute : DrawerAttribute
    {
        private Vector2 _min;
        private Vector2 _max;
        private readonly UColor _color;

        public CurveRangeAttribute(Vector2 min, Vector2 max, UColor color = UColor.Clear)
        {
            _min = min;
            _max = max;
            _color = color;
        }

        public CurveRangeAttribute(UColor color) : this(Vector2.zero, Vector2.one, color) { }

        public CurveRangeAttribute(float minX, float minY, float maxX, float maxY, UColor color = UColor.Clear) : this(new Vector2(minX, minY), new Vector2(maxX, maxY), color) { }

        public Vector2 Min => _min;
        public Vector2 Max => _max;
        public UColor Color => _color;
    }
}
