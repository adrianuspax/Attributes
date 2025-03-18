using System;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;
    using ASPax.Attributes.Utility;

    public class HorizontalLineTest : MonoBehaviour
    {
        [HorizontalLine(color: XColor.Black)]
        [Header("Black")]
        [HorizontalLine(color: XColor.Blue)]
        [Header("Blue")]
        [HorizontalLine(color: XColor.Gray)]
        [Header("Gray")]
        [HorizontalLine(color: XColor.Green)]
        [Header("Green")]
        [HorizontalLine(color: XColor.Indigo)]
        [Header("Indigo")]
        [HorizontalLine(color: XColor.Orange)]
        [Header("Orange")]
        [HorizontalLine(color: XColor.Pink)]
        [Header("Pink")]
        [HorizontalLine(color: XColor.Red)]
        [Header("Red")]
        [HorizontalLine(color: XColor.Violet)]
        [Header("Violet")]
        [HorizontalLine(color: XColor.White)]
        [Header("White")]
        [HorizontalLine(color: XColor.Yellow)]
        [Header("Yellow")]
        [HorizontalLine(10.0f)]
        [Header("Thick")]
        public int line0;

        public HorizontalLineNest1 nest1;
    }

    [Serializable]
    public class HorizontalLineNest1
    {
        [HorizontalLine]
        public int line1;

        public HorizontalLineNest2 nest2;
    }

    [Serializable]
    public class HorizontalLineNest2
    {
        [HorizontalLine]
        public int line2;
    }
}
