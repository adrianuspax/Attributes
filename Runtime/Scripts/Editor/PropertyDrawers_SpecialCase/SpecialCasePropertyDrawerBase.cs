using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using Attributes.Drawer.SpecialCases;
    using Attributes.Validator;

    public abstract class SpecialCasePropertyDrawerBase
    {
        public void OnGUI(Rect rect, SerializedProperty property)
        {
            var visible = PropertyUtility.IsVisible(property); // Check if visible

            if (!visible)
                return;

            var validatorAttributes = PropertyUtility.GetAttributes<ValidatorAttribute>(property); // Validate

            foreach (var validatorAttribute in validatorAttributes)
                validatorAttribute.GetValidator().ValidateProperty(property);

            EditorGUI.BeginChangeCheck(); // Check if enabled and draw

            var enabled = PropertyUtility.IsEnabled(property);

            using (new EditorGUI.DisabledScope(disabled: !enabled))
            {
                OnGUI_Internal(rect, property, PropertyUtility.GetLabel(property));
            }

            if (EditorGUI.EndChangeCheck()) // Call OnValueChanged callbacks
                PropertyUtility.CallOnValueChangedCallbacks(property);
        }

        public float GetPropertyHeight(SerializedProperty property)
        {
            return GetPropertyHeight_Internal(property);
        }

        protected abstract void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label);
        protected abstract float GetPropertyHeight_Internal(SerializedProperty property);
    }

    public static class SpecialCaseDrawerAttributeExtensions
    {
        private static readonly Dictionary<Type, SpecialCasePropertyDrawerBase> _drawersByAttributeType;

        static SpecialCaseDrawerAttributeExtensions()
        {
            _drawersByAttributeType = new() { [typeof(ReorderableListAttribute)] = ReorderableListPropertyDrawer.Instance };
        }

        public static SpecialCasePropertyDrawerBase GetDrawer(this SpecialCaseDrawerAttribute attr)
        {
            if (_drawersByAttributeType.TryGetValue(attr.GetType(), out SpecialCasePropertyDrawerBase drawer))
                return drawer;
            else
                return null;
        }
    }
}
