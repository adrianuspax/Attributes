using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using Attributes.Drawer;

    [CustomPropertyDrawer(typeof(MinMaxSliderAttribute))]
    public class MinMaxSliderPropertyDrawer : PropertyDrawerBase
    {
        protected override float GetPropertyHeight_Internal(SerializedProperty property, GUIContent label)
        {
            return (property.propertyType == SerializedPropertyType.Vector2 || property.propertyType == SerializedPropertyType.Vector2Int) ? GetPropertyHeight(property) : GetPropertyHeight(property) + GetHelpBoxHeight();
        }

        protected override void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);

            var minMaxSliderAttribute = (MinMaxSliderAttribute)attribute;

            if (property.propertyType == SerializedPropertyType.Vector2 || property.propertyType == SerializedPropertyType.Vector2Int)
            {
                EditorGUI.BeginProperty(rect, label, property);

                var indentLength = NaughtyEditorGUI.GetIndentLength(rect);
                var labelWidth = EditorGUIUtility.labelWidth + NaughtyEditorGUI.HorizontalSpacing;
                var floatFieldWidth = EditorGUIUtility.fieldWidth;
                var sliderWidth = rect.width - labelWidth - 2.0f * floatFieldWidth;
                var sliderPadding = 5.0f;

                var labelRect = new Rect()
                {
                    x = rect.x,
                    y = rect.y,
                    width = labelWidth,
                    height = rect.height
                };

                var sliderRect = new Rect()
                {
                    x = rect.x + labelWidth + floatFieldWidth + sliderPadding - indentLength,
                    y = rect.y,
                    width = sliderWidth - 2.0f * sliderPadding + indentLength,
                    height = rect.height
                };

                var minFloatFieldRect = new Rect()
                {
                    x = rect.x + labelWidth - indentLength,
                    y = rect.y,
                    width = floatFieldWidth + indentLength,
                    height = rect.height
                };

                var maxFloatFieldRect = new Rect()
                {
                    x = rect.x + labelWidth + floatFieldWidth + sliderWidth - indentLength,
                    y = rect.y,
                    width = floatFieldWidth + indentLength,
                    height = rect.height
                };

                EditorGUI.LabelField(labelRect, label.text); // Draw the label
                EditorGUI.BeginChangeCheck(); // Draw the slider

                if (property.propertyType == SerializedPropertyType.Vector2)
                {
                    var sliderValue = property.vector2Value;
                    EditorGUI.MinMaxSlider(sliderRect, ref sliderValue.x, ref sliderValue.y, minMaxSliderAttribute.Value.min, minMaxSliderAttribute.Value.max);

                    sliderValue.x = EditorGUI.FloatField(minFloatFieldRect, sliderValue.x);
                    sliderValue.x = Mathf.Clamp(sliderValue.x, minMaxSliderAttribute.Value.min, Mathf.Min(minMaxSliderAttribute.Value.max, sliderValue.y));

                    sliderValue.y = EditorGUI.FloatField(maxFloatFieldRect, sliderValue.y);
                    sliderValue.y = Mathf.Clamp(sliderValue.y, Mathf.Max(minMaxSliderAttribute.Value.min, sliderValue.x), minMaxSliderAttribute.Value.max);

                    if (EditorGUI.EndChangeCheck())
                        property.vector2Value = sliderValue;
                }
                else if (property.propertyType == SerializedPropertyType.Vector2Int)
                {
                    var sliderValue = property.vector2IntValue;
                    float xValue = sliderValue.x;
                    float yValue = sliderValue.y;
                    EditorGUI.MinMaxSlider(sliderRect, ref xValue, ref yValue, minMaxSliderAttribute.Value.min, minMaxSliderAttribute.Value.max);

                    sliderValue.x = EditorGUI.IntField(minFloatFieldRect, (int)xValue);
                    sliderValue.x = (int)Mathf.Clamp(sliderValue.x, minMaxSliderAttribute.Value.min, Mathf.Min(minMaxSliderAttribute.Value.max, sliderValue.y));

                    sliderValue.y = EditorGUI.IntField(maxFloatFieldRect, (int)yValue);
                    sliderValue.y = (int)Mathf.Clamp(sliderValue.y, Mathf.Max(minMaxSliderAttribute.Value.min, sliderValue.x), minMaxSliderAttribute.Value.max);

                    if (EditorGUI.EndChangeCheck())
                        property.vector2IntValue = sliderValue;
                }

                EditorGUI.EndProperty();
            }
            else
            {
                var message = minMaxSliderAttribute.GetType().Name + " can be used only on Vector2 or Vector2Int fields";
                DrawDefaultPropertyAndHelpBox(rect, property, message, MessageType.Warning);
            }

            EditorGUI.EndProperty();
        }
    }
}