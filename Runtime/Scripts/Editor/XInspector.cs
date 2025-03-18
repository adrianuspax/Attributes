using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using ASPax.Attributes.Drawer;
    using ASPax.Attributes.Drawer.SpecialCases;
    using ASPax.Attributes.Meta;
    using ASPax.Attributes.Utility;

    [CanEditMultipleObjects]
    [CustomEditor(typeof(UnityEngine.Object), true)]
    public class XInspector : UnityEditor.Editor
    {
        private List<SerializedProperty> _serializedProperties = new();
        private IEnumerable<FieldInfo> _nonSerializedFields;
        private IEnumerable<PropertyInfo> _nativeProperties;
        private IEnumerable<MethodInfo> _methods;
        private readonly Dictionary<string, SavedBool> _foldouts = new();

        protected virtual void OnEnable()
        {
            Type type;

            type = typeof(ShowNonSerializedFieldAttribute);
            _nonSerializedFields = ReflectionUtility.GetAllFields(target, f => f.GetCustomAttributes(type, true).Length > 0);
            type = typeof(ShowNativePropertyAttribute);
            _nativeProperties = ReflectionUtility.GetAllProperties(target, p => p.GetCustomAttributes(type, true).Length > 0);
            type = typeof(ButtonAttribute);
            _methods = ReflectionUtility.GetAllMethods(target, m => m.GetCustomAttributes(type, true).Length > 0);
        }

        protected virtual void OnDisable()
        {
            ReorderableListPropertyDrawer.Instance.ClearCache();
        }

        public override void OnInspectorGUI()
        {
            GetSerializedProperties(ref _serializedProperties);

            var anyNaughtyAttribute = _serializedProperties.Any(p => PropertyUtility.GetAttribute<IAtribute>(p) != null);

            if (anyNaughtyAttribute)
                DrawSerializedProperties();
            else
                DrawDefaultInspector();

            DrawNonSerializedFields();
            DrawNativeProperties();
            DrawButtons();
        }

        protected void GetSerializedProperties(ref List<SerializedProperty> outSerializedProperties)
        {
            outSerializedProperties.Clear();

            using var iterator = serializedObject.GetIterator();

            if (iterator.NextVisible(true))
                do
                    outSerializedProperties.Add(serializedObject.FindProperty(iterator.name));
                while (iterator.NextVisible(false));
        }

        protected void DrawSerializedProperties()
        {
            serializedObject.Update();

            foreach (var property in GetNonGroupedProperties(_serializedProperties)) // Draw non-grouped serialized properties
            {
                if (property.name.Equals("m_Script", StringComparison.Ordinal))
                    using (new EditorGUI.DisabledScope(disabled: true))
                        EditorGUILayout.PropertyField(property);
                else
                    XGUI.PropertyField_Layout(property, includeChildren: true);
            }

            foreach (var group in GetGroupedProperties(_serializedProperties)) // Draw grouped serialized properties
            {
                IEnumerable<SerializedProperty> visibleProperties = group.Where(p => PropertyUtility.IsVisible(p));

                if (visibleProperties.Any())
                {
                    XGUI.BeginBoxGroup_Layout(group.Key);

                    foreach (var property in visibleProperties)
                        XGUI.PropertyField_Layout(property, includeChildren: true);

                    XGUI.EndBoxGroup_Layout();
                }
            }

            foreach (var group in GetFoldoutProperties(_serializedProperties)) // Draw foldout serialized properties
            {
                IEnumerable<SerializedProperty> visibleProperties = group.Where(p => PropertyUtility.IsVisible(p));

                if (!visibleProperties.Any())
                    continue;

                if (!_foldouts.ContainsKey(group.Key))
                    _foldouts[group.Key] = new SavedBool($"{target.GetInstanceID()}.{group.Key}", false);

                _foldouts[group.Key].Value = EditorGUILayout.Foldout(_foldouts[group.Key].Value, group.Key, true);

                if (_foldouts[group.Key].Value)
                    foreach (var property in visibleProperties)
                        XGUI.PropertyField_Layout(property, true);
            }

            serializedObject.ApplyModifiedProperties();
        }

        protected void DrawNonSerializedFields(bool drawHeader = false)
        {
            if (_nonSerializedFields.Any())
            {
                if (drawHeader)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Non-Serialized Fields", GetHeaderGUIStyle());
                    var rect = EditorGUILayout.GetControlRect(false);
                    XGUI.HorizontalLine(rect, HorizontalLineAttribute.HEIGHT, HorizontalLineAttribute.COLOR.GetColor());
                }

                foreach (var field in _nonSerializedFields)
                    XGUI.NonSerializedField_Layout(serializedObject.targetObject, field);
            }
        }

        protected void DrawNativeProperties(bool drawHeader = false)
        {
            if (_nativeProperties.Any())
            {
                if (drawHeader)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Native Properties", GetHeaderGUIStyle());
                    var rect = EditorGUILayout.GetControlRect(false);
                    XGUI.HorizontalLine(rect, HorizontalLineAttribute.HEIGHT, HorizontalLineAttribute.COLOR.GetColor());
                }

                foreach (var property in _nativeProperties)
                    XGUI.NativeProperty_Layout(serializedObject.targetObject, property);
            }
        }

        protected void DrawButtons(bool drawHeader = false)
        {
            if (_methods.Any())
            {
                if (drawHeader)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Buttons", GetHeaderGUIStyle());
                    var rect = EditorGUILayout.GetControlRect(false);
                    XGUI.HorizontalLine(rect, HorizontalLineAttribute.HEIGHT, HorizontalLineAttribute.COLOR.GetColor());
                }

                foreach (var method in _methods)
                    XGUI.Button(serializedObject.targetObject, method);
            }
        }

        private static IEnumerable<SerializedProperty> GetNonGroupedProperties(IEnumerable<SerializedProperty> properties)
        {
            return properties.Where(p => PropertyUtility.GetAttribute<IGroupAttribute>(p) == null);
        }

        private static IEnumerable<IGrouping<string, SerializedProperty>> GetGroupedProperties(IEnumerable<SerializedProperty> properties)
        {
            return properties.Where(p => PropertyUtility.GetAttribute<BoxGroupAttribute>(p) != null).GroupBy(p => PropertyUtility.GetAttribute<BoxGroupAttribute>(p).Name);
        }

        private static IEnumerable<IGrouping<string, SerializedProperty>> GetFoldoutProperties(IEnumerable<SerializedProperty> properties)
        {
            return properties.Where(p => PropertyUtility.GetAttribute<FoldoutAttribute>(p) != null).GroupBy(p => PropertyUtility.GetAttribute<FoldoutAttribute>(p).Name);
        }

        private static GUIStyle GetHeaderGUIStyle()
        {
            GUIStyle style = new(EditorStyles.centeredGreyMiniLabel)
            {
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.UpperCenter
            };

            return style;
        }
    }
}
