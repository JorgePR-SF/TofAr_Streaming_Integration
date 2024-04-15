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
    public class ShoulderUpControlController : ControllerBase
    {
        /// <summary>
        /// Enable ShoulderUpControl
        /// </summary>
        public bool ShoulderUpControl
        {
            get
            {
                return shoulderUpControl;
            }

            set
            {
                if (value != shoulderUpControl)
                {
                    shoulderUpControl = value;
                    TofArHumanoidManager.Instance.ShoulderUpControl = shoulderUpControl;
                    OnChangeShoulderUpControl?.Invoke(shoulderUpControl);
                }
            }
        }

        bool shoulderUpControl = true;

        public UnityAction<bool> OnChangeShoulderUpControl;

        protected override void Start()
        {
            shoulderUpControl = TofArHumanoidManager.Instance.ShoulderUpControl;
            base.Start();
        }
    }
}
