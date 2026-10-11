using UnityEngine;

namespace ASPax.Test
{
    public class SceneTest : MonoBehaviour
    {
        [Attributes.Scene]
        public string scene0;

        public SceneNest1 nest1;
    }

    [System.Serializable]
    public class SceneNest1
    {
        [Attributes.Scene]
        public string scene1;

        public SceneNest2 nest2;
    }

    [System.Serializable]
    public struct SceneNest2
    {
        [Attributes.Scene]
        public int scene2;
    }
}
