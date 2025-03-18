using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;
    using ASPax.Attributes.Utility;

    public class ProgressBarTest : MonoBehaviour
    {
        [Header("Constant ProgressBar")]
        [ProgressBar("Health", 100, XColor.Red)]
        public float health = 50.0f;

        [Header("Nested ProgressBar")]
        public ProgressBarNest1 nest1;

        [Header("Dynamic ProgressBar")]
        [ProgressBar("Elixir", "maxElixir", color: XColor.Violet)]
        public int elixir = 50;
        public int maxElixir = 100;
    }

    [System.Serializable]
    public class ProgressBarNest1
    {
        [ProgressBar("Mana", 100, XColor.Blue)]
        public float mana = 25.0f;

        public ProgressBarNest2 nest2;
    }

    [System.Serializable]
    public class ProgressBarNest2
    {
        [ProgressBar("Stamina", 100, XColor.Green)]
        public float stamina = 75.0f;
    }
}
