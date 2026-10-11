using System;

namespace ASPax.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class LabelAttribute : MetaAttribute
    {
        private readonly string _label;

        public LabelAttribute(string label)
        {
            _label = label;
        }

        public string Label => _label;
    }
}
