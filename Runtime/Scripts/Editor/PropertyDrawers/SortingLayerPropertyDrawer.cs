﻿using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using Attributes.Drawer;

    [CustomPropertyDrawer(typeof(SortingLayerAttribute))]
    public class SortingLayerPropertyDrawer : PropertyDrawerBase
    {
        private const string TypeWarningMessage = "{0} must be an int or a string";

        protected override float GetPropertyHeight_Internal(SerializedProperty property, GUIContent label)
        {
            var validPropertyType = property.propertyType == SerializedPropertyType.String || property.propertyType == SerializedPropertyType.Integer;
            return validPropertyType ? GetPropertyHeight(property) : GetPropertyHeight(property) + GetHelpBoxHeight();
        }

        protected override void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);

            switch (property.propertyType)
            {
                case SerializedPropertyType.String:
                    DrawPropertyForString(rect, property, label, GetLayers());
                    break;
                case SerializedPropertyType.Integer:
                    DrawPropertyForInt(rect, property, label, GetLayers());
                    break;
                default:
                    string message = string.Format(TypeWarningMessage, property.name);
                    DrawDefaultPropertyAndHelpBox(rect, property, message, MessageType.Warning);
                    break;
            }

            EditorGUI.EndProperty();
        }

        private string[] GetLayers()
        {
            var internalEditorUtilityType = typeof(UnityEditorInternal.InternalEditorUtility);
            var sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
            return (string[])sortingLayersProperty.GetValue(null, new object[0]);
        }

        private static void DrawPropertyForString(Rect rect, SerializedProperty property, GUIContent label, string[] layers)
        {
            var index = IndexOf(layers, property.stringValue);
            var newIndex = EditorGUI.Popup(rect, label.text, index, layers);
            var newLayer = layers[newIndex];

            if (!property.stringValue.Equals(newLayer, StringComparison.Ordinal))
                property.stringValue = layers[newIndex];
        }

        private static void DrawPropertyForInt(Rect rect, SerializedProperty property, GUIContent label, string[] layers)
        {
            var index = 0;
            var layerName = SortingLayer.IDToName(property.intValue);

            for (int i = 0; i < layers.Length; i++)
            {
                if (layerName.Equals(layers[i], StringComparison.Ordinal))
                {
                    index = i;
                    break;
                }
            }

            var newIndex = EditorGUI.Popup(rect, label.text, index, layers);
            var newLayerName = layers[newIndex];
            var newLayerNumber = SortingLayer.NameToID(newLayerName);

            if (property.intValue != newLayerNumber)
                property.intValue = newLayerNumber;
        }

        private static int IndexOf(string[] layers, string layer)
        {
            var index = Array.IndexOf(layers, layer);
            return Mathf.Clamp(index, 0, layers.Length - 1);
        }
    }
}
