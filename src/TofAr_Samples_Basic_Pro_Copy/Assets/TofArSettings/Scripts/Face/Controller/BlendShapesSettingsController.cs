/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2023 Sony Semiconductor Solutions Corporation.
 *
 */

using TofAr.V0.Face;
using UnityEngine.Events;

namespace TofArSettings.Face
{
    public class BlendShapesSettingsController : ControllerBase
    {
        /// <summary>
        /// Enable/Disable VRMBlendShapesEnable
        /// </summary>
        public bool VRMBlendShapesEnable
        {
            get
            {
                return vrmBlendShapesEnable;
            }

            set
            {
                if (value != vrmBlendShapesEnable)
                {
                    vrmBlendShapesEnable = value;
                    SetProperty();
                    OnChangeVRMBlendShapesEnable?.Invoke(vrmBlendShapesEnable);
                }
            }
        }

        bool vrmBlendShapesEnable = false;

        public UnityAction<bool> OnChangeVRMBlendShapesEnable;

        protected override void Start()
        {
            VRMBlendShapesEnable = TofArFaceManager.Instance?.VRMBlendShapesEnable == true;
            base.Start();
        }

        /// <summary>
        /// Apply BlendShapesSettingsProperty property
        /// </summary>
        void SetProperty()
        {
            var mgr = TofArFaceManager.Instance;
            if (!mgr)
            {
                return;
            }

            mgr.VRMBlendShapesEnable = vrmBlendShapesEnable;
        }
    }
}
