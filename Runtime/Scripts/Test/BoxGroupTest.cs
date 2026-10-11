using UnityEngine;

namespace ASPax.Test
{
    public class BoxGroupTest : MonoBehaviour
    {
        [Attributes.BoxGroup("Integers")]
        public int int0;
        [Attributes.BoxGroup("Integers")]
        public int int1;

        [Attributes.BoxGroup("Floats")]
        public float float0;
        [Attributes.BoxGroup("Floats")]
        public float float1;

        [Attributes.BoxGroup("Sliders")]
        [Attributes.MinMaxSlider(0, 1)]
        public Vector2 slider0;
        [Attributes.BoxGroup("Sliders")]
        [Attributes.MinMaxSlider(0, 1)]
        public Vector2 slider1;

        public string str0;
        public string str1;

        [Attributes.BoxGroup]
        public Transform trans0;
        [Attributes.BoxGroup]
        public Transform trans1;
    }
}
