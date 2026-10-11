using System;

namespace ASPax.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public class OnValueChangedAttribute : MetaAttribute
    {
        private readonly string _callbackName;

        public OnValueChangedAttribute(string callbackName)
        {
            _callbackName = callbackName;
        }

        public string CallbackName => _callbackName;
    }
}
