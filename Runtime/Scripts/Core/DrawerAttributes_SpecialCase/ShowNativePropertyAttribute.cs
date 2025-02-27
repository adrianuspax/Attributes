using System;

namespace ASPax.Attributes.Drawer.SpecialCases
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ShowNativePropertyAttribute : SpecialCaseDrawerAttribute { }
}
