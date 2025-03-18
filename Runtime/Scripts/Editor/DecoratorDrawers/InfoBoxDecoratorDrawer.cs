using UnityEditor;
using UnityEngine;

namespace ASPax.Editor
{
    using Attributes.Drawer;

    [CustomPropertyDrawer(typeof(InfoBoxAttribute))]
    public class InfoBoxDecoratorDrawer : DecoratorDrawer
    {
        public override float GetHeight()
        {
            return GetHelpBoxHeight();
        }

        public override void OnGUI(Rect rect)
        {
            var infoBoxAttribute = (InfoBoxAttribute)attribute;
            var indentLength = XGUI.GetIndentLength(rect);
            var infoBoxRect = new Rect()
            {
                x = rect.x + indentLength,
                y = rect.y,
                width = rect.width - indentLength,
                height = GetHelpBoxHeight()
            };


            DrawInfoBox(infoBoxRect, infoBoxAttribute.Text, infoBoxAttribute.Type);
        }

        private float GetHelpBoxHeight()
        {
            var infoBoxAttribute = (InfoBoxAttribute)attribute;
            var minHeight = EditorGUIUtility.singleLineHeight * 2.0f;
            var desiredHeight = GUI.skin.box.CalcHeight(new GUIContent(infoBoxAttribute.Text), EditorGUIUtility.currentViewWidth);
            var height = Mathf.Max(minHeight, desiredHeight);

            return height;
        }

        private void DrawInfoBox(Rect rect, string infoText, InfoBoxType infoBoxType)
        {
            var messageType = MessageType.None;
            switch (infoBoxType)
            {
                case InfoBoxType.Normal:
                    messageType = MessageType.Info;
                    break;

                case InfoBoxType.Warning:
                    messageType = MessageType.Warning;
                    break;

                case InfoBoxType.Error:
                    messageType = MessageType.Error;
                    break;
            }

            XGUI.HelpBox(rect, infoText, messageType);
        }
    }
}
