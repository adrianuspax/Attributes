using System.Collections;
using UnityEngine;

namespace ASPax.Test
{
    using ASPax.Attributes.Drawer.SpecialCases;

    public class ButtonTest : MonoBehaviour
    {
        public int myInt;

        [Button(enabledMode: SButtonEnableMode.Always)]
        private void IncrementMyInt()
        {
            myInt++;
        }

        [Button("Decrement My Int", SButtonEnableMode.Editor)]
        private void DecrementMyInt()
        {
            myInt--;
        }

        [Button(enabledMode: SButtonEnableMode.Playmode)]
        private void LogMyInt(string prefix = "MyInt = ")
        {
            Debug.Log(prefix + myInt);
        }

        [Button("StartCoroutine")]
        private IEnumerator IncrementMyIntCoroutine()
        {
            int seconds = 5;
            for (int i = 0; i < seconds; i++)
            {
                myInt++;
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
