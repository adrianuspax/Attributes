using System;

namespace ASPax.Attributes.Meta
{
    using Utility;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class DisableIfAttribute : EnableIfAttributeBase
    {
        public DisableIfAttribute(string condition) : base(condition)
        {
            isInverted = true;
        }

        public DisableIfAttribute(XConditionOperator conditionOperator, params string[] conditions) : base(conditionOperator, conditions)
        {
            isInverted = true;
        }

        public DisableIfAttribute(string enumName, object enumValue) : base(enumName, enumValue as Enum)
        {
            isInverted = true;
        }
    }
}
