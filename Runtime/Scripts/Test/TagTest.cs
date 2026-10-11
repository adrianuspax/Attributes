using UnityEngine;

namespace ASPax.Test
{
    public class TagTest : MonoBehaviour
    {
        [Attributes.Tag]
        public string tag0;

        public TagNest1 nest1;

        [Attributes.Button]
        private void LogTag0()
        {
            Debug.Log(tag0);
        }
    }

    [System.Serializable]
    public class TagNest1
    {
        [Attributes.Tag]
        public string tag1;

        public TagNest2 nest2;
    }

    [System.Serializable]
    public struct TagNest2
    {
        [Attributes.Tag]
        public string tag2;
    }
}
