using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using Attributes.Drawer;

    [CustomPropertyDrawer(typeof(DropdownAttribute))]
    public class DropdownPropertyDrawer : PropertyDrawerBase
    {
        protected override float GetPropertyHeight_Internal(SerializedProperty property, GUIContent label)
        {
            var dropdownAttribute = (DropdownAttribute)attribute;
            var values = GetValues(property, dropdownAttribute.ValuesName);
            var fieldInfo = ReflectionUtility.GetField(PropertyUtility.GetTargetObjectWithProperty(property), property.name);
            var propertyHeight = AreValuesValid(values, fieldInfo) ? GetPropertyHeight(property) : GetPropertyHeight(property) + GetHelpBoxHeight();

            return propertyHeight;
        }

        protected override void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);

            var dropdownAttribute = (DropdownAttribute)attribute;
            var target = PropertyUtility.GetTargetObjectWithProperty(property);
            var valuesObject = GetValues(property, dropdownAttribute.ValuesName);
            var dropdownField = ReflectionUtility.GetField(target, property.name);

            if (AreValuesValid(valuesObject, dropdownField))
            {
                if (valuesObject is IList list && dropdownField.FieldType == GetElementType(valuesObject))
                {
                    var selectedValue = dropdownField.GetValue(target); // Selected value
                    var valuesList = list; // Values and display options
                    var values = new object[valuesList.Count];
                    var displayOptions = new string[valuesList.Count];

                    for (int i = 0; i < values.Length; i++)
                    {
                        var value = valuesList[i];
                        values[i] = value;
                        displayOptions[i] = value == null ? "<null>" : value.ToString();
                    }

                    var selectedValueIndex = Array.IndexOf(values, selectedValue); // Selected value index

                    if (selectedValueIndex < 0)
                        selectedValueIndex = 0;

                    XGUI.Dropdown(rect, property.serializedObject, target, dropdownField, label.text, selectedValueIndex, values, displayOptions);
                }
                else if (valuesObject is IDropdownList list1)
                {
                    var selectedValue = dropdownField.GetValue(target); // Current value
                    var index = -1; // Current value index, values and display options
                    var selectedValueIndex = -1;
                    var values = new List<object>();
                    var displayOptions = new List<string>();
                    var dropdown = list1;

                    using (IEnumerator<KeyValuePair<string, object>> dropdownEnumerator = dropdown.GetEnumerator())
                    {
                        while (dropdownEnumerator.MoveNext())
                        {
                            index++;
                            var current = dropdownEnumerator.Current;

                            if (current.Value?.Equals(selectedValue) == true)
                                selectedValueIndex = index;

                            values.Add(current.Value);

                            if (current.Key == null)
                                displayOptions.Add("<null>");
                            else if (string.IsNullOrWhiteSpace(current.Key))
                                displayOptions.Add("<empty>");
                            else
                                displayOptions.Add(current.Key);
                        }
                    }

                    if (selectedValueIndex < 0)
                        selectedValueIndex = 0;

                    XGUI.Dropdown(rect, property.serializedObject, target, dropdownField, label.text, selectedValueIndex, values.ToArray(), displayOptions.ToArray());
                }
            }
            else
            {
                var message = string.Format("Invalid values with name '{0}' provided to '{1}'. Either the values name is incorrect or the types of the target field and the values field/property/method don't match", dropdownAttribute.ValuesName, dropdownAttribute.GetType().Name);
                DrawDefaultPropertyAndHelpBox(rect, property, message, MessageType.Warning);
            }

            EditorGUI.EndProperty();
        }

        private object GetValues(SerializedProperty property, string valuesName)
        {
            var target = PropertyUtility.GetTargetObjectWithProperty(property);
            var valuesFieldInfo = ReflectionUtility.GetField(target, valuesName);

            if (valuesFieldInfo != null)
                return valuesFieldInfo.GetValue(target);

            var valuesPropertyInfo = ReflectionUtility.GetProperty(target, valuesName);

            if (valuesPropertyInfo != null)
                return valuesPropertyInfo.GetValue(target);

            var methodValuesInfo = ReflectionUtility.GetMethod(target, valuesName);

            if (methodValuesInfo != null && methodValuesInfo.ReturnType != typeof(void) && methodValuesInfo.GetParameters().Length == 0)
                return methodValuesInfo.Invoke(target, null);

            return null;
        }

        private bool AreValuesValid(object values, FieldInfo dropdownField)
        {
            if (values == null || dropdownField == null)
                return false;

            if ((values is IList && dropdownField.FieldType == GetElementType(values)) || (values is IDropdownList))
                return true;

            return false;
        }

        private Type GetElementType(object values)
        {
            var valuesType = values.GetType();
            var elementType = ReflectionUtility.GetListElementType(valuesType);
            return elementType;
        }
    }
}