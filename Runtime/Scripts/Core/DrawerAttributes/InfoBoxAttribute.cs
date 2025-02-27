using System;

namespace ASPax.Attributes.Drawer
{
    public enum InfoBoxType
    {
        Normal,
        Warning,
        Error
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class InfoBoxAttribute : DrawerAttribute
    {
        private readonly string _text;
        private readonly InfoBoxType _type;

        public InfoBoxAttribute(string text, InfoBoxType type = InfoBoxType.Normal)
        {
            _text = text;
            _type = type;
        }

        public string Text => _text;
        public InfoBoxType Type => _type;
    }
}
