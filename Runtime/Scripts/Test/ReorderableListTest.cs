using System;
using System.Collections.Generic;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer.SpecialCases;

    public class ReorderableListTest : MonoBehaviour
    {
        [ReorderableList]
        public int[] intArray;

        [ReorderableList]
        public List<Vector3> vectorList;

        [ReorderableList]
        public List<SomeStruct> structList;

        [ReorderableList]
        public GameObject[] gameObjectsList;

        [ReorderableList]
        public List<Transform> transformsList;

        [ReorderableList]
        public List<MonoBehaviour> monoBehavioursList;
    }

    [Serializable]
    public struct SomeStruct
    {
        public int Int;
        public float Float;
        public Vector3 Vector;
    }
}
