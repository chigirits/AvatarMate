using nadena.dev.modular_avatar.core;
using System;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using VRC.SDKBase;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace tokyo.chigiri.avatarmatevrc
{

    [ExecuteInEditMode]
    [Serializable]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ModularAvatarBoneProxy))]
    [RequireComponent(typeof(ModularAvatarVisibleHeadAccessory))]
    public class MAViewPositionProxy : MonoBehaviour, IEditorOnly
    {

#if UNITY_EDITOR

        VRCAvatarDescriptor descriptor;
        Transform head;
        float nextTime = 0f;
        const float interval = 1f;

        void Awake()
        {
            var proxy = GetComponent<ModularAvatarBoneProxy>();
            if (proxy == null) return;
            proxy.boneReference = HumanBodyBones.Head;
            proxy.attachmentMode = BoneProxyAttachmentMode.AsChildKeepPosition;
        }

        void Update()
        {
            if (Time.time < nextTime) return;
            nextTime = Time.time + interval;
            if (descriptor == null) descriptor = GetComponentInParent<VRCAvatarDescriptor>();
            if (descriptor == null) return;
            var p = descriptor.transform.TransformDirection(descriptor.ViewPosition);
            transform.position = p;
            if (head == null) head = descriptor.GetComponent<Animator>()?.GetBoneTransform(HumanBodyBones.Head);
            if (head == null) return;
            transform.rotation = head.rotation;
        }

#endif

    }

}
