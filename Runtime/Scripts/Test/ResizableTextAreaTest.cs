﻿using System;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;

    public class ResizableTextAreaTest : MonoBehaviour
    {
        [ResizableTextArea]
        public string text0;

        public ResizableTextAreaNest1 nest1;
    }

    [Serializable]
    public class ResizableTextAreaNest1
    {
        [ResizableTextArea]
        public string text1;

        public ResizableTextAreaNest2 nest2;
    }

    [Serializable]
    public class ResizableTextAreaNest2
    {
        [ResizableTextArea]
        public string text2;
    }
}
