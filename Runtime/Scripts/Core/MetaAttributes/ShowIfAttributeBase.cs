using System;

namespace ASPax.Attributes.Meta
{
    using Utility;

    public class ShowIfAttributeBase : MetaAttribute
    {
        private readonly string[] _conditions;
        private readonly XConditionOperator _conditionOperator;
        protected bool isInverted;
        public Enum _enumValue;

        public ShowIfAttributeBase(string condition)
        {
            _conditionOperator = XConditionOperator.And;
            _conditions = new string[1] { condition };
        }

        public ShowIfAttributeBase(XConditionOperator conditionOperator, params string[] conditions)
        {
            _conditionOperator = conditionOperator;
            _conditions = conditions;
        }

        public ShowIfAttributeBase(string enumName, Enum enumValue) : this(enumName)
        {
            _enumValue = enumValue ?? throw new ArgumentNullException(nameof(enumValue), "This parameter must be an enum value.");
        }
        /// <summary>
        /// If this not null, <see cref="Conditions"/>[0] is name of an enum variable.
        /// </summary>
        public Enum EnumValue => _enumValue;
        public string[] Conditions => _conditions;
        public XConditionOperator ConditionOperator => _conditionOperator;
        public bool IsInverted => isInverted;
    }
}
