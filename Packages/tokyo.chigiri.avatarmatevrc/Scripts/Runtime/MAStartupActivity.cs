using System;
using UnityEngine;
using VRC.SDKBase;

namespace tokyo.chigiri.avatarmatevrc
{

    [Serializable]
    [DisallowMultipleComponent]
    public class MAStartupActivity : MonoBehaviour, IEditorOnly
    {
        public enum Activity
        {
            DontChange,
            Inactive,
            Active,
        }

        public Activity startupActivity = Activity.DontChange;

        void Reset()
        {
            startupActivity = gameObject.activeSelf ? Activity.Active : Activity.Inactive;
        }

        public void DoEffect()
        {
            switch (startupActivity)
            {
                case Activity.Inactive: gameObject.SetActive(false); break;
                case Activity.Active: gameObject.SetActive(true); break;
            }
        }

    }

}
