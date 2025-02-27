using System;

namespace ASPax.Attributes.Drawer.SpecialCases
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ShowNonSerializedFieldAttribute : SpecialCaseDrawerAttribute { }
}
