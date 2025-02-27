using System.Collections.Generic;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer;

    //[CreateAssetMenu(fileName = "NaughtyScriptableObject", menuName = "NaughtyAttributes/_NaughtyScriptableObject")]
    public class NaughtyScriptableObject : ScriptableObject
    {
        [Expandable]
        public List<TestScriptableObjectA> listA;
    }
}
