using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer.SpecialCases;

    public class ShowNonSerializedFieldTest : MonoBehaviour
    {
#pragma warning disable 414
        [ShowNonSerializedField]
        private readonly ushort myUShort = ushort.MaxValue;

        [ShowNonSerializedField]
        private readonly short myShort = short.MaxValue;

        [ShowNonSerializedField]
        private readonly uint myUInt = uint.MaxValue;

        [ShowNonSerializedField]
        private readonly int myInt = 10;

        [ShowNonSerializedField]
        private readonly ulong myULong = ulong.MaxValue;

        [ShowNonSerializedField]
        private readonly long myLong = long.MaxValue;

        [ShowNonSerializedField]
        private const float PI = 3.14159f;

        [ShowNonSerializedField]
        private static readonly Vector3 CONST_VECTOR = Vector3.one;
#pragma warning restore 414
    }
}
