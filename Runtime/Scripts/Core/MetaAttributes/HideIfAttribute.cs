using System;

namespace ASPax.Attributes.Meta
{
    using Utility;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HideIfAttribute : ShowIfAttributeBase
    {
        public HideIfAttribute(string condition) : base(condition)
        {
            isInverted = true;
        }

        public HideIfAttribute(UConditionOperator conditionOperator, params string[] conditions) : base(conditionOperator, conditions)
        {
            isInverted = true;
        }

        public HideIfAttribute(string enumName, object enumValue) : base(enumName, enumValue as Enum)
        {
            isInverted = true;
        }
    }
}
