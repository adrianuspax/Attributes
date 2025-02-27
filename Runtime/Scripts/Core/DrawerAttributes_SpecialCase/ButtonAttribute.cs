using System;

namespace ASPax.Attributes.Drawer.SpecialCases
{
    public enum SButtonEnableMode
    {
        /// <summary>
        /// Button should be active always
        /// </summary>
        Always,
        /// <summary>
        /// Button should be active only in editor
        /// </summary>
        Editor,
        /// <summary>
        /// Button should be active only in playmode
        /// </summary>
        Playmode
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ButtonAttribute : SpecialCaseDrawerAttribute
    {
        private readonly string _text;
        private readonly SButtonEnableMode _selectedEnableMode;

        public ButtonAttribute(string text = null, SButtonEnableMode enabledMode = SButtonEnableMode.Always)
        {
            _text = text;
            _selectedEnableMode = enabledMode;
        }

        public string Text => _text;
        public SButtonEnableMode SelectedEnableMode => _selectedEnableMode;
    }
}
