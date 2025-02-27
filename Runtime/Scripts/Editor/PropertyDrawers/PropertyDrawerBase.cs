using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using ASPax.Attributes.Drawer.SpecialCases;
    using ASPax.Attributes.Validator;

    public abstract class PropertyDrawerBase : PropertyDrawer
    {
        public sealed override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
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

        protected abstract void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label);

        sealed override public float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var visible = PropertyUtility.IsVisible(property);

            if (!visible)
                return 0.0f;

            return GetPropertyHeight_Internal(property, label);
        }

        protected virtual float GetPropertyHeight_Internal(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, includeChildren: true);
        }

        protected float GetPropertyHeight(SerializedProperty property)
        {
            var specialCaseAttribute = PropertyUtility.GetAttribute<SpecialCaseDrawerAttribute>(property);

            if (specialCaseAttribute != null)
                return specialCaseAttribute.GetDrawer().GetPropertyHeight(property);

            return EditorGUI.GetPropertyHeight(property, includeChildren: true);
        }

        public virtual float GetHelpBoxHeight()
        {
            return EditorGUIUtility.singleLineHeight * 2.0f;
        }

        public void DrawDefaultPropertyAndHelpBox(Rect rect, SerializedProperty property, string message, MessageType messageType)
        {
            var indentLength = NaughtyEditorGUI.GetIndentLength(rect);
            var helpBoxRect = new Rect()
            {
                x = rect.x + indentLength,
                y = rect.y,
                width = rect.width - indentLength,
                height = GetHelpBoxHeight()
            };

            NaughtyEditorGUI.HelpBox(helpBoxRect, message, MessageType.Warning, context: property.serializedObject.targetObject);

            var propertyRect = new Rect()
            {
                x = rect.x,
                y = rect.y + GetHelpBoxHeight(),
                width = rect.width,
                height = GetPropertyHeight(property)
            };

            EditorGUI.PropertyField(propertyRect, property, true);
        }
    }
}
