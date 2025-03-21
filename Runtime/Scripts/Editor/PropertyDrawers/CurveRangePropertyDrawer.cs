﻿using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using Attributes.Drawer;
    using Attributes.Utility;

    [CustomPropertyDrawer(typeof(CurveRangeAttribute))]
    public class CurveRangePropertyDrawer : PropertyDrawerBase
    {
        protected override float GetPropertyHeight_Internal(SerializedProperty property, GUIContent label)
        {
            var propertyHeight = property.propertyType == SerializedPropertyType.AnimationCurve ? GetPropertyHeight(property) : GetPropertyHeight(property) + GetHelpBoxHeight();
            return propertyHeight;
        }

        protected override void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);

            if (property.propertyType != SerializedPropertyType.AnimationCurve) // Check user error
            {
                var message = string.Format("Field {0} is not an AnimationCurve", property.name);
                DrawDefaultPropertyAndHelpBox(rect, property, message, MessageType.Warning);
                return;
            }

            var curveRangeAttribute = (CurveRangeAttribute)attribute;
            var curveRanges = new Rect()
            {
                x = curveRangeAttribute.Min.x,
                y = curveRangeAttribute.Min.y,
                width = curveRangeAttribute.Max.x - curveRangeAttribute.Min.x,
                height = curveRangeAttribute.Max.y - curveRangeAttribute.Min.y
            };

            EditorGUI.CurveField(rect, property, curveRangeAttribute.Color == XColor.Clear ? Color.green : curveRangeAttribute.Color.GetColor(), curveRanges, label);
            EditorGUI.EndProperty();
        }
    }
}
