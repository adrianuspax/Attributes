using UnityEngine;

namespace ASPax.Test
{
    public class AnimatorParamTest : MonoBehaviour
    {
        public Animator animator0;

        [Attributes.Drawer.AnimatorParam("animator0")]
        public int hash0;

        [Attributes.Drawer.AnimatorParam("animator0")]
        public string name0;

        public AnimatorParamNest1 nest1;

        [Attributes.Drawer.SpecialCases.Button("Log 'hash0' and 'name0'")]
        private void TestLog()
        {
            Debug.Log($"hash0 = {hash0}");
            Debug.Log($"name0 = {name0}");
            Debug.Log($"Animator.StringToHash(name0) = {Animator.StringToHash(name0)}");
        }
    }

    [System.Serializable]
    public class AnimatorParamNest1
    {
        public Animator animator1;
        private Animator Animator1 => animator1;

        [Attributes.Drawer.AnimatorParam("Animator1", AnimatorControllerParameterType.Bool)]
        public int hash1;

        [Attributes.Drawer.AnimatorParam("Animator1", AnimatorControllerParameterType.Float)]
        public string name1;

        public AnimatorParamNest2 nest2;
    }

    [System.Serializable]
    public class AnimatorParamNest2
    {
        public Animator animator2;
        private Animator GetAnimator2() => animator2;

        [Attributes.Drawer.AnimatorParam("GetAnimator2", AnimatorControllerParameterType.Int)]
        public int hash1;

        [Attributes.Drawer.AnimatorParam("GetAnimator2", AnimatorControllerParameterType.Trigger)]
        public string name1;
    }
}
