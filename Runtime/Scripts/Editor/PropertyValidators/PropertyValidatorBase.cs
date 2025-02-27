﻿using System;
using System.Collections.Generic;
using UnityEditor;

namespace ASPax.Editor
{
    using Attributes.Validator;

    public abstract class PropertyValidatorBase
    {
        public abstract void ValidateProperty(SerializedProperty property);
    }

    public static class ValidatorAttributeExtensions
    {
        private static readonly Dictionary<Type, PropertyValidatorBase> _validatorsByAttributeType;

        static ValidatorAttributeExtensions()
        {
            _validatorsByAttributeType = new()
            {
                [typeof(MinValueAttribute)] = new MinValuePropertyValidator(),
                [typeof(MaxValueAttribute)] = new MaxValuePropertyValidator(),
                [typeof(RequiredAttribute)] = new RequiredPropertyValidator(),
                [typeof(ValidateInputAttribute)] = new ValidateInputPropertyValidator()
            };
        }

        public static PropertyValidatorBase GetValidator(this ValidatorAttribute attr)
        {
            if (_validatorsByAttributeType.TryGetValue(attr.GetType(), out PropertyValidatorBase validator))
                return validator;
            else
                return null;
        }
    }
}
