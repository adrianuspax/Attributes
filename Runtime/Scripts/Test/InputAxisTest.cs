﻿using System;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;
    using ASPax.Attributes.Drawer.SpecialCases;

    public class InputAxisTest : MonoBehaviour
    {
        [InputAxis]
        public string inputAxis0;

        public InputAxisNest1 nest1;

        [Button]
        private void LogInputAxis0()
        {
            Debug.Log(inputAxis0);
        }
    }

    [Serializable]
    public class InputAxisNest1
    {
        [InputAxis]
        public string inputAxis1;

        public InputAxisNest2 nest2;
    }

    [Serializable]
    public struct InputAxisNest2
    {
        [InputAxis]
        public string inputAxis2;
    }
}
