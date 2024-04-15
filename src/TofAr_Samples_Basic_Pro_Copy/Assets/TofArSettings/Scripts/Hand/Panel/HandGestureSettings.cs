/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2022,2023 Sony Semiconductor Solutions Corporation.
 *
 */

using UnityEngine;
using UnityEngine.Events;

namespace TofArSettings.Hand
{
    public class HandGestureSettings : UI.SettingsBase
    {
        GestureController gestureCtrl;
        GestureTypeController gestureTypeCtrl;
        

        UI.ItemToggle itemEnable, itemAcc, itemTypeBoth;
        

        protected override void Start()
        {
            // Set UI order
            uiOrder = new UnityAction[]
            {
                MakeUIEnable,
                MakeUIGestureType
            };

            gestureCtrl = FindObjectOfType<GestureController>();
            controllers.Add(gestureCtrl);
            gestureTypeCtrl = gestureCtrl.GetComponent<GestureTypeController>();
            controllers.Add(gestureTypeCtrl);
            
            
            base.Start();
        }

        /// <summary>
        /// Make UI
        /// </summary>
        void MakeUIEnable()
        {
            itemEnable = settings.AddItem("Enabled", gestureCtrl.OnOff, ChangeEnable);
            gestureCtrl.OnChangeEnable += (onOff) =>
            {
                itemEnable.OnOff = onOff;
            };
        }

        /// <summary>
        /// Toggle gesture recognition
        /// </summary>
        /// <param name="onOff">On/Off</param>
        void ChangeEnable(bool onOff)
        {
            gestureCtrl.OnOff = onOff;
        }

        /// <summary>
        /// Make UI
        /// </summary>
        void MakeUIGestureType()
        {
            itemTypeBoth = settings.AddItem("Enable BothHands Gesture", gestureTypeCtrl.BothHands, ChangeTypeBoth);
            gestureTypeCtrl.OnChangeBothHands += (onOff) =>
            {
                itemTypeBoth.OnOff = onOff;
            };
        }

        /// <summary>
        /// Toggle gesture type bothhand
        /// </summary>
        /// <param name="onOff">On/Off</param>
        void ChangeTypeBoth(bool onOff)
        {
            gestureTypeCtrl.BothHands = onOff;
        }

        
    }
}
