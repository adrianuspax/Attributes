using System;

namespace ASPax.Attributes.Validator
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ValidateInputAttribute : ValidatorAttribute
    {
        private readonly string _callbackName;
        private readonly string _message;

        public ValidateInputAttribute(string callbackName, string message = null)
        {
            _callbackName = callbackName;
            _message = message;
        }

        public string CallbackName => _callbackName;
        public string Message => _message;
    }
}
