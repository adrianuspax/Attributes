using System;

namespace ASPax.Attributes.Drawer
{
    using ASPax.Attributes.Utility;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class HorizontalLineAttribute : DrawerAttribute
    {
        public const float HEIGHT = 2.0f;
        public const UColor COLOR = UColor.Gray;

        private readonly float _height;
        private readonly UColor _color;

        public HorizontalLineAttribute(float height = HEIGHT, UColor color = COLOR)
        {
            _height = height;
            _color = color;
        }

        public float Height => _height;
        public UColor Color => _color;
    }
}
