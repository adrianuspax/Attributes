using System;

namespace ASPax.Attributes.Validator
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class RequiredAttribute : ValidatorAttribute
    {
        private readonly string _message;

        public RequiredAttribute(string message = null)
        {
            _message = message;
        }

        public string Message => _message;
    }
}
