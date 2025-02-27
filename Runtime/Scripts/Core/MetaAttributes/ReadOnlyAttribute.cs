using System;

namespace ASPax.Attributes.Meta
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ReadOnlyAttribute : MetaAttribute { }
}
