using UnityEditor;

namespace ASPax.Editor
{
    using Attributes.Validator;

    public class ValidateInputPropertyValidator : PropertyValidatorBase
    {
        public override void ValidateProperty(SerializedProperty property)
        {
            var validateInputAttribute = PropertyUtility.GetAttribute<ValidateInputAttribute>(property);
            var target = PropertyUtility.GetTargetObjectWithProperty(property);
            var validationCallback = ReflectionUtility.GetMethod(target, validateInputAttribute.CallbackName);

            if (validationCallback != null && validationCallback.ReturnType == typeof(bool))
            {
                var callbackParameters = validationCallback.GetParameters();

                if (callbackParameters.Length == 0)
                {
                    if (!(bool)validationCallback.Invoke(target, null))
                    {
                        if (string.IsNullOrEmpty(validateInputAttribute.Message))
                            XGUI.HelpBox_Layout(property.name + " is not valid", MessageType.Error, context: property.serializedObject.targetObject);
                        else
                            XGUI.HelpBox_Layout(validateInputAttribute.Message, MessageType.Error, context: property.serializedObject.targetObject);
                    }
                }
                else if (callbackParameters.Length == 1)
                {
                    var fieldInfo = ReflectionUtility.GetField(target, property.name);
                    var fieldType = fieldInfo.FieldType;
                    var parameterType = callbackParameters[0].ParameterType;

                    if (fieldType == parameterType)
                    {
                        if (!(bool)validationCallback.Invoke(target, new object[] { fieldInfo.GetValue(target) }))
                        {
                            if (string.IsNullOrEmpty(validateInputAttribute.Message))
                                XGUI.HelpBox_Layout(property.name + " is not valid", MessageType.Error, context: property.serializedObject.targetObject);
                            else
                                XGUI.HelpBox_Layout(validateInputAttribute.Message, MessageType.Error, context: property.serializedObject.targetObject);
                        }
                    }
                    else
                    {
                        var warning = "The field type is not the same as the callback's parameter type";
                        XGUI.HelpBox_Layout(warning, MessageType.Warning, context: property.serializedObject.targetObject);
                    }
                }
                else
                {
                    string warning = validateInputAttribute.GetType().Name + " needs a callback with boolean return type and an optional single parameter of the same type as the field";
                    XGUI.HelpBox_Layout(warning, MessageType.Warning, context: property.serializedObject.targetObject);
                }
            }
        }
    }
}
