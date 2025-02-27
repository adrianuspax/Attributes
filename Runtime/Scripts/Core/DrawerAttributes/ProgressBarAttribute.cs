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
        private readonly UColor color;

        public ProgressBarAttribute(string name, float maxValue, UColor color = UColor.Blue)
        {
            this.name = name;
            this.maxValue = maxValue;
            this.color = color;
        }

        public ProgressBarAttribute(string name, string maxValueName, UColor color = UColor.Blue)
        {
            this.name = name;
            this.maxValueName = maxValueName;
            this.color = color;
        }

        public ProgressBarAttribute(float maxValue, UColor color = UColor.Blue) : this(string.Empty, maxValue, color) { }

        public ProgressBarAttribute(string maxValueName, UColor color = UColor.Blue) : this(string.Empty, maxValueName, color) { }

        public string Name => name;
        public float MaxValue => maxValue;
        public string MaxValueName => maxValueName;
        public UColor Color => color;
    }
}
