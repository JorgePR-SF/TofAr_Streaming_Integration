/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2023 Sony Semiconductor Solutions Corporation.
 *
 */

using TofAr.V0.Humanoid;
using UnityEngine.Events;

namespace TofArSettings.Humanoid
{
    public class UseFaceController : ControllerBase
    {
        /// <summary>
        /// Enable UseFace
        /// </summary>
        public bool UseFace
        {
            get
            {
                return useFace;
            }

            set
            {
                if (value != useFace)
                {
                    useFace = value;
                    TofArHumanoidManager.Instance.UseFace = useFace;
                    OnChangeUseFace?.Invoke(useFace);
                }
            }
        }

        bool useFace = true;

        public UnityAction<bool> OnChangeUseFace;

        protected override void Start()
        {
            useFace = TofArHumanoidManager.Instance.UseFace;
            base.Start();
        }
    }
}
