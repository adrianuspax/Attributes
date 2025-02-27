using System;

namespace ASPax.Attributes.Drawer
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class SortingLayerAttribute : DrawerAttribute { }
}