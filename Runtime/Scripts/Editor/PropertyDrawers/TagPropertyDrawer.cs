using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using Attributes.Drawer;

    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagPropertyDrawer : PropertyDrawerBase
    {
        protected override float GetPropertyHeight_Internal(SerializedProperty property, GUIContent label)
        {
            return (property.propertyType == SerializedPropertyType.String) ? GetPropertyHeight(property) : GetPropertyHeight(property) + GetHelpBoxHeight();
        }

        protected override void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);

            if (property.propertyType == SerializedPropertyType.String)
            {
                var tagList = new List<string> // generate the taglist + custom tags
                {
                    "(None)",
                    "Untagged"
                };

                tagList.AddRange(UnityEditorInternal.InternalEditorUtility.tags);

                var propertyString = property.stringValue;
                var index = 0;

                for (var i = 1; i < tagList.Count; i++) // check if there is an entry that matches the entry and get the index // we skip index 0 as that is a special custom case
                {
                    if (tagList[i].Equals(propertyString, StringComparison.Ordinal))
                    {
                        index = i;
                        break;
                    }
                }

                var newIndex = EditorGUI.Popup(rect, label.text, index, tagList.ToArray()); // Draw the popup box with the current selected index
                var newValue = newIndex > 0 ? tagList[newIndex] : string.Empty; // Adjust the actual string value of the property based on the selection

                if (!property.stringValue.Equals(newValue, StringComparison.Ordinal))
                    property.stringValue = newValue;
            }
            else
            {
                var message = string.Format("{0} supports only string fields", typeof(TagAttribute).Name);
                DrawDefaultPropertyAndHelpBox(rect, property, message, MessageType.Warning);
            }

            EditorGUI.EndProperty();
        }
    }
}
