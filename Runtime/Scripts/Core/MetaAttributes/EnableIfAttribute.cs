using System;

namespace ASPax.Attributes.Meta
{
    using Utility;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class EnableIfAttribute : EnableIfAttributeBase
    {
        public EnableIfAttribute(string condition) : base(condition)
        {
            isInverted = false;
        }

        public EnableIfAttribute(XConditionOperator conditionOperator, params string[] conditions) : base(conditionOperator, conditions)
        {
            isInverted = false;
        }

        public EnableIfAttribute(string enumName, object enumValue) : base(enumName, enumValue as Enum)
        {
            isInverted = false;
        }
    }
}
