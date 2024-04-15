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
    public class UseHandController : ControllerBase
    {
        /// <summary>
        /// Enable UseHand
        /// </summary>
        public bool UseHand
        {
            get
            {
                return useHand;
            }

            set
            {
                if (value != useHand)
                {
                    useHand = value;
                    TofArHumanoidManager.Instance.UseHand = useHand;
                    OnChangeUseHand?.Invoke(useHand);
                }
            }
        }

        bool useHand = true;

        public UnityAction<bool> OnChangeUseHand;

        protected override void Start()
        {
            useHand = TofArHumanoidManager.Instance.UseHand;
            base.Start();
        }
    }
}
