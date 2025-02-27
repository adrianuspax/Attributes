using System;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;

    public class InfoBoxTest : MonoBehaviour
    {
        [InfoBox("Normal", InfoBoxType.Normal)]
        public int normal;

        public InfoBoxNest1 nest1;
    }

    [Serializable]
    public class InfoBoxNest1
    {
        [InfoBox("Warning", InfoBoxType.Warning)]
        public int warning;

        public InfoBoxNest2 nest2;
    }

    [Serializable]
    public class InfoBoxNest2
    {
        [InfoBox("Error", InfoBoxType.Error)]
        public int error;
    }
}
