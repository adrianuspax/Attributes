using System;

namespace ASPax.Attributes.Meta
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class FoldoutAttribute : MetaAttribute, IGroupAttribute
    {
        private readonly string _name;

        public FoldoutAttribute(string name)
        {
            _name = name;
        }

        public string Name => _name;
    }
}
