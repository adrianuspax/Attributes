using System;

namespace ASPax.Attributes.Drawer
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ExpandableAttribute : DrawerAttribute { }
}
