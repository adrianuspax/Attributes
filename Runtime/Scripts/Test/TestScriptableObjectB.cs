using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;

    //[CreateAssetMenu(fileName = "TestScriptableObjectB", menuName = "NaughtyAttributes/TestScriptableObjectB")]
    public class TestScriptableObjectB : ScriptableObject
    {
        [MinMaxSlider(0, 10)]
        public Vector2Int slider;
    }
}