using System;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;
    using ASPax.Attributes.Utility;

    public class CurveRangeTest : MonoBehaviour
    {
        [CurveRange(0f, 0f, 1f, 1f, UColor.Yellow)]
        public AnimationCurve[] curves;

        [CurveRange(-1, -1, 1, 1, UColor.Red)]
        public AnimationCurve curve;

        [CurveRange(UColor.Orange)]
        public AnimationCurve curve1;

        [CurveRange(0, 0, 10, 10)]
        public AnimationCurve curve2;

        public CurveRangeNest1 nest1;

        [Serializable]
        public class CurveRangeNest1
        {
            [CurveRange(0, 0, 1, 1, UColor.Green)]
            public AnimationCurve curve;

            public CurveRangeNest2 nest2;
        }

        [Serializable]
        public class CurveRangeNest2
        {
            [CurveRange(0, 0, 5, 5, UColor.Blue)]
            public AnimationCurve curve;
        }
    }
}
