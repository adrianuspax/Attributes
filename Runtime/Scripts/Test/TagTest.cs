using UnityEngine;

namespace ASPax.Test
{
    public class TagTest : MonoBehaviour
    {
        [Attributes.Drawer.Tag]
        public string tag0;

        public TagNest1 nest1;

        [Attributes.Drawer.SpecialCases.Button]
        private void LogTag0()
        {
            Debug.Log(tag0);
        }
    }

    [System.Serializable]
    public class TagNest1
    {
        [Attributes.Drawer.Tag]
        public string tag1;

        public TagNest2 nest2;
    }

    [System.Serializable]
    public struct TagNest2
    {
        [Attributes.Drawer.Tag]
        public string tag2;
    }
}
