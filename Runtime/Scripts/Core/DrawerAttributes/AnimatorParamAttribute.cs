using System;
using UnityEngine;

namespace ASPax.Attributes.Drawer
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class AnimatorParamAttribute : DrawerAttribute
    {
        private readonly string _animatorName;
        private readonly AnimatorControllerParameterType? _animatorParamType;

        public AnimatorParamAttribute(string animatorName)
        {
            _animatorName = animatorName;
            _animatorParamType = null;
        }

        public AnimatorParamAttribute(string animatorName, AnimatorControllerParameterType animatorParamType)
        {
            _animatorName = animatorName;
            _animatorParamType = animatorParamType;
        }

        public string AnimatorName => _animatorName;
        public AnimatorControllerParameterType? AnimatorParamType => _animatorParamType;
    }
}
