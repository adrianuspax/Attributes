using System;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;
    using ASPax.Attributes.Utility;

    public class HorizontalLineTest : MonoBehaviour
    {
        [HorizontalLine(color: UColor.Black)]
        [Header("Black")]
        [HorizontalLine(color: UColor.Blue)]
        [Header("Blue")]
        [HorizontalLine(color: UColor.Gray)]
        [Header("Gray")]
        [HorizontalLine(color: UColor.Green)]
        [Header("Green")]
        [HorizontalLine(color: UColor.Indigo)]
        [Header("Indigo")]
        [HorizontalLine(color: UColor.Orange)]
        [Header("Orange")]
        [HorizontalLine(color: UColor.Pink)]
        [Header("Pink")]
        [HorizontalLine(color: UColor.Red)]
        [Header("Red")]
        [HorizontalLine(color: UColor.Violet)]
        [Header("Violet")]
        [HorizontalLine(color: UColor.White)]
        [Header("White")]
        [HorizontalLine(color: UColor.Yellow)]
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
