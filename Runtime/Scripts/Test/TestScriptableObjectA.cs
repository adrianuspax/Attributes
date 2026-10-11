using System.Collections.Generic;
using UnityEngine;

namespace ASPax.Test
{
    using Attributes;
    //[CreateAssetMenu(fileName = "TestScriptableObjectA", menuName = "NaughtyAttributes/TestScriptableObjectA")]
    public class TestScriptableObjectA : ScriptableObject
    {
        [Expandable]
        public List<TestScriptableObjectB> listB;
    }
}