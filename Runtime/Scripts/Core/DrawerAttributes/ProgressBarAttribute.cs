using System;

namespace ASPax.Attributes.Drawer
{
    using Utility;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ProgressBarAttribute : DrawerAttribute
    {
        private readonly string name;
        private readonly float maxValue;
        private readonly string maxValueName;
        private readonly XColor color;

        public ProgressBarAttribute(string name, float maxValue, XColor color = XColor.Blue)
        {
            this.name = name;
            this.maxValue = maxValue;
            this.color = color;
        }

        public ProgressBarAttribute(string name, string maxValueName, XColor color = XColor.Blue)
        {
            this.name = name;
            this.maxValueName = maxValueName;
            this.color = color;
        }

        public ProgressBarAttribute(float maxValue, XColor color = XColor.Blue) : this(string.Empty, maxValue, color) { }

        public ProgressBarAttribute(string maxValueName, XColor color = XColor.Blue) : this(string.Empty, maxValueName, color) { }

        public string Name => name;
        public float MaxValue => maxValue;
        public string MaxValueName => maxValueName;
        public XColor Color => color;
    }
}
