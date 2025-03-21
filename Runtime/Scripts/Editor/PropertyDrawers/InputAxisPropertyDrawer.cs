﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using Attributes.Drawer;

    [CustomPropertyDrawer(typeof(InputAxisAttribute))]
    public class InputAxisPropertyDrawer : PropertyDrawerBase
    {
        private static readonly string AssetPath = Path.Combine("ProjectSettings", "InputManager.asset");
        private const string AxesPropertyPath = "m_Axes";
        private const string NamePropertyPath = "m_Name";

        protected override float GetPropertyHeight_Internal(SerializedProperty property, GUIContent label)
        {
            return (property.propertyType == SerializedPropertyType.String) ? GetPropertyHeight(property) : GetPropertyHeight(property) + GetHelpBoxHeight();
        }

        protected override void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);

            if (property.propertyType == SerializedPropertyType.String)
            {
                var inputManagerAsset = AssetDatabase.LoadAssetAtPath(AssetPath, typeof(object));
                var inputManager = new SerializedObject(inputManagerAsset);
                var axesProperty = inputManager.FindProperty(AxesPropertyPath);
                var axesSet = new HashSet<string> { "(None)" };

                for (var i = 0; i < axesProperty.arraySize; i++)
                {
                    var axis = axesProperty.GetArrayElementAtIndex(i).FindPropertyRelative(NamePropertyPath).stringValue;
                    axesSet.Add(axis);
                }

                var axes = axesSet.ToArray();
                var propertyString = property.stringValue;
                var index = 0;

                for (var i = 1; i < axes.Length; i++) // check if there is an entry that matches the entry and get the index // we skip index 0 as that is a special custom case
                {
                    if (axes[i].Equals(propertyString, StringComparison.Ordinal))
                    {
                        index = i;
                        break;
                    }
                }

                var newIndex = EditorGUI.Popup(rect, label.text, index, axes); // Draw the popup box with the current selected index
                var newValue = newIndex > 0 ? axes[newIndex] : string.Empty; // Adjust the actual string value of the property based on the selection

                if (!property.stringValue.Equals(newValue, StringComparison.Ordinal))
                    property.stringValue = newValue;
            }
            else
            {
                var message = string.Format("{0} supports only string fields", typeof(InputAxisAttribute).Name);
                DrawDefaultPropertyAndHelpBox(rect, property, message, MessageType.Warning);
            }

            EditorGUI.EndProperty();
        }
    }
}
