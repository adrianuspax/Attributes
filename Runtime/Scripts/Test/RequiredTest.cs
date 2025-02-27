using UnityEngine;

namespace ASPax.Test
{
    public class RequiredTest : MonoBehaviour
    {
        [Attributes.Validator.Required]
        public Transform trans0;
        public RequiredNest1 nest1;
    }

    [System.Serializable]
    public class RequiredNest1
    {
        [Attributes.Validator.Required]
        [Attributes.Drawer.AllowNesting] // Because it's nested we need to explicitly allow nesting
        public Transform trans1;
        public RequiredNest2 nest2;
    }

    [System.Serializable]
    public class RequiredNest2
    {
        [Attributes.Validator.Required("trans2 is invalid custom message - hohoho")]
        [Attributes.Drawer.AllowNesting] // Because it's nested we need to explicitly allow nesting
        public Transform trans2;
    }
}
