using UnityEngine;

namespace ASPax.Test
{
    public class MinMaxSliderTest : MonoBehaviour
    {
        [Attributes.Drawer.MinMaxSlider(0.0f, 1.0f)]
        public Vector2 minMaxSlider0 = new(0.25f, 0.75f);
        public MinMaxSliderNest1 nest1;
    }

    [System.Serializable]
    public class MinMaxSliderNest1
    {
        [Attributes.Drawer.MinMaxSlider(0.0f, 1.0f)]
        public Vector2 minMaxSlider1 = new(0.25f, 0.75f);
        public MinMaxSliderNest2 nest2;
    }

    [System.Serializable]
    public class MinMaxSliderNest2
    {
        [Attributes.Drawer.MinMaxSlider(1, 11)]
        public Vector2Int minMaxSlider2 = new(6, 11);
    }
}
