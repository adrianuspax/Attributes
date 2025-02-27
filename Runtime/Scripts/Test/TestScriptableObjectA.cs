using System.Collections.Generic;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;
    //[CreateAssetMenu(fileName = "TestScriptableObjectA", menuName = "NaughtyAttributes/TestScriptableObjectA")]
    public class TestScriptableObjectA : ScriptableObject
    {
        [Expandable]
        public List<TestScriptableObjectB> listB;
    }
}