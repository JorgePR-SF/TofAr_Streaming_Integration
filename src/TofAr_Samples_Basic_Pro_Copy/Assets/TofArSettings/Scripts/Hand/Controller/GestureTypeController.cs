/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2022,2023 Sony Semiconductor Solutions Corporation.
 *
 */

using System;
using TofAr.V0.Hand;

namespace TofArSettings.Hand
{
    public class GestureTypeController : ControllerBase
    {
        public bool BothHands
        {
            get
            {
                return TofArHandManager.Instance.enableBothHandsGesture;
            }

            set
            {
                TofArHandManager.Instance.enableBothHandsGesture = value;
                ReStartGestureEstimation();
                OnChangeBothHands?.Invoke(value);
            }
        }

        public event ChangeToggleEvent OnChangeBothHands;

        protected override void Start()
        {
            BothHands = TofArHandManager.Instance.enableBothHandsGesture;
            base.Start();
        }

        private void ReStartGestureEstimation()
        {
            if (TofArHandManager.Instance.IsGestureEstimating)
            {
                TofArHandManager.Instance.StopGestureEstimation();
                TofArHandManager.Instance.StartGestureEstimation();
            }
        }

    }
}
