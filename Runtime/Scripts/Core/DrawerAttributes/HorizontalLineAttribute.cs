using System;

namespace ASPax.Attributes.Drawer
{
    using ASPax.Attributes.Utility;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class HorizontalLineAttribute : DrawerAttribute
    {
        public const float HEIGHT = 2.0f;
        public const XColor COLOR = XColor.Gray;

        private readonly float _height;
        private readonly XColor _color;

        public HorizontalLineAttribute(float height = HEIGHT, XColor color = COLOR)
        {
            _height = height;
            _color = color;
        }

        public float Height => _height;
        public XColor Color => _color;
    }
}
