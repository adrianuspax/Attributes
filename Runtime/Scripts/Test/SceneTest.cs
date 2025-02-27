using UnityEngine;

namespace ASPax.Test
{
    public class SceneTest : MonoBehaviour
    {
        [Attributes.Drawer.Scene]
        public string scene0;

        public SceneNest1 nest1;
    }

    [System.Serializable]
    public class SceneNest1
    {
        [Attributes.Drawer.Scene]
        public string scene1;

        public SceneNest2 nest2;
    }

    [System.Serializable]
    public struct SceneNest2
    {
        [Attributes.Drawer.Scene]
        public int scene2;
    }
}
