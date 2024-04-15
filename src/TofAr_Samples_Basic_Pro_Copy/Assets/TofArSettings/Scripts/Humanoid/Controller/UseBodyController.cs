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
    public class UseBodyController : ControllerBase
    {
        /// <summary>
        /// Enable UseBody
        /// </summary>
        public bool UseBody
        {
            get
            {
                return useBody;
            }

            set
            {
                if (value != useBody)
                {
                    useBody = value;
                    TofArHumanoidManager.Instance.UseBody = useBody;
                    OnChangeUseBody?.Invoke(useBody);
                }
            }
        }

        bool useBody = true;

        public UnityAction<bool> OnChangeUseBody;

        protected override void Start()
        {
            useBody = TofArHumanoidManager.Instance.UseBody;
            base.Start();
        }
    }
}
