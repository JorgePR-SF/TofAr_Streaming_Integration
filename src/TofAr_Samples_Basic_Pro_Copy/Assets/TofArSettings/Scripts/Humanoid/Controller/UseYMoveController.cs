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
    public class UseYMoveController : ControllerBase
    {
        /// <summary>
        /// Enable UseYMove
        /// </summary>
        public bool UseYMove
        {
            get
            {
                return useYMove;
            }

            set
            {
                if (value != useYMove)
                {
                    useYMove = value;
                    TofArHumanoidManager.Instance.UseYMove = useYMove;
                    OnChangeUseYMove?.Invoke(useYMove);
                }
            }
        }

        bool useYMove = true;

        public UnityAction<bool> OnChangeUseYMove;

        protected override void Start()
        {
            useYMove = TofArHumanoidManager.Instance.UseYMove;
            base.Start();
        }
    }
}
