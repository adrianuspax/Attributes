using UnityEditor;

namespace ASPax.Editor
{
    using Attributes.Validator;

    public class RequiredPropertyValidator : PropertyValidatorBase
    {
        public override void ValidateProperty(SerializedProperty property)
        {
            var requiredAttribute = PropertyUtility.GetAttribute<RequiredAttribute>(property);

            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                if (property.objectReferenceValue == null)
                {
                    var errorMessage = property.name + " is required";

                    if (!string.IsNullOrEmpty(requiredAttribute.Message))
                        errorMessage = requiredAttribute.Message;

                    XGUI.HelpBox_Layout(errorMessage, MessageType.Error, context: property.serializedObject.targetObject);
                }
            }
            else
            {
                var warning = requiredAttribute.GetType().Name + " works only on reference types";
                XGUI.HelpBox_Layout(warning, MessageType.Warning, context: property.serializedObject.targetObject);
            }
        }
    }
}
