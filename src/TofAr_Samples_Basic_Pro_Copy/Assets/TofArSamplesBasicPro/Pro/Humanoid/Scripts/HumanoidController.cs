/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2023 Sony Semiconductor Solutions Corporation.
 *
 */

using TofAr.V0.Humanoid;
using UnityEngine;

namespace TofArSamples.Humanoid
{
    /// <summary>
    /// HumanoidController
    /// </summary>
    public class HumanoidController : MonoBehaviour
    {
        private TofArHumanoidManager humanoidManager;

        /// <summary>
        /// Model Animator
        /// </summary>
        public Animator modelAnimator;

        /// <summary>
        /// Apply HipMotion State
        /// </summary>
        [SerializeField]
        bool applyHipMotion = true;

        private void Awake()
        {
            humanoidManager = TofArHumanoidManager.Instance;
        }

        private void Update()
        {
            if ((modelAnimator == null) || (humanoidManager.HumanoidData == null))
            {
                return;
            }

            if (applyHipMotion)
            {
                var rootTf = modelAnimator.GetBoneTransform(HumanBodyBones.Hips).parent;
                rootTf.localPosition = humanoidManager.HumanoidData.rootPose.position;
                rootTf.localRotation = humanoidManager.HumanoidData.rootPose.rotation;
            }

            foreach (HumanBodyBones hi in System.Enum.GetValues(typeof(HumanBodyBones)))
            {
                if (hi == HumanBodyBones.LastBone)
                {
                    continue;
                }

                var bone = modelAnimator.GetBoneTransform(hi);
                if (bone != null)
                {
                    bone.localRotation = humanoidManager.HumanoidData.boneLocalRotations[(int)hi];
                }
            }
        }
    }
}
