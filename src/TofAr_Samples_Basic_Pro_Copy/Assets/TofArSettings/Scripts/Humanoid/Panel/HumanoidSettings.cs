/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2023 Sony Semiconductor Solutions Corporation.
 *
 */

using UnityEngine.Events;

namespace TofArSettings.Humanoid
{
    public class HumanoidSettings : UI.SettingsBase
    {
        UseHandController useHandController;
        UseBodyController useBodyController;
        UseFaceController useFaceController;
        UseYMoveController useYMoveController;
        ShoulderUpControlController shoulderUpControlController;
        NoiseReductionLevelController noiseReductionLevelController;

        UI.ItemToggle itemUseHand,itemUseBody,itemUseFace,itemUseYMove, itemshoulderUpControl;
        UI.ItemDropdown itemNoiseReduction;

        protected override void Start()
        {
            // Set UI order
            uiOrder = new UnityAction[]
            {
                MakeUIUseHand,
                MakeUIUseBody,
                MakeUIUseFace,
                MakeUIUseYMove,
                MakeUIShoulderUpControl,
                MakeUINoiseReductionLevel
            };

            useHandController = FindObjectOfType<UseHandController>();
            controllers.Add(useHandController);
            useBodyController = FindObjectOfType<UseBodyController>();
            controllers.Add(useBodyController);
            useFaceController = FindObjectOfType<UseFaceController>();
            controllers.Add(useFaceController);
            useYMoveController = FindObjectOfType<UseYMoveController>();
            controllers.Add(useYMoveController);
            shoulderUpControlController = FindObjectOfType<ShoulderUpControlController>();
            controllers.Add(shoulderUpControlController);
            noiseReductionLevelController = FindObjectOfType<NoiseReductionLevelController>();
            controllers.Add(noiseReductionLevelController);

            base.Start();
        }

        private void MakeUIUseHand()
        {
            itemUseHand = settings.AddItem("Use Hand", useHandController.UseHand, ChangeUseHand);
            useHandController.OnChangeUseHand += (val) =>
            {
                itemUseHand.OnOff = val;
            };

        }

        private void ChangeUseHand(bool onOff)
        {
            useHandController.UseHand = onOff;
        }

        private void MakeUIUseBody()
        {
            itemUseBody = settings.AddItem("Use Body", useBodyController.UseBody, ChangeUseBody);
            useBodyController.OnChangeUseBody += (val) =>
            {
                itemUseBody.OnOff = val;
            };

        }

        private void ChangeUseBody(bool onOff)
        {
            useBodyController.UseBody = onOff;
        }

        private void MakeUIUseFace()
        {
            itemUseFace = settings.AddItem("Use Face", useFaceController.UseFace, ChangeUseFace);
            useFaceController.OnChangeUseFace += (val) =>
            {
                itemUseFace.OnOff = val;
            };

        }

        private void ChangeUseFace(bool onOff)
        {
            useFaceController.UseFace = onOff;
        }

        private void MakeUIUseYMove()
        {
            itemUseYMove = settings.AddItem("Use Y Move", useYMoveController.UseYMove, ChangeUseYMove);
            useYMoveController.OnChangeUseYMove += (val) =>
            {
                itemUseYMove.OnOff = val;
            };

        }

        private void ChangeUseYMove(bool onOff)
        {
            useYMoveController.UseYMove = onOff;
        }

        private void MakeUIShoulderUpControl()
        {
            itemshoulderUpControl = settings.AddItem("Shoulder Up Control", shoulderUpControlController.ShoulderUpControl, ChangeShoulderUpControl);
            shoulderUpControlController.OnChangeShoulderUpControl += (val) =>
            {
                itemshoulderUpControl.OnOff = val;
            };

        }

        private void ChangeShoulderUpControl(bool onOff)
        {
            shoulderUpControlController.ShoulderUpControl = onOff;
        }

        private void MakeUINoiseReductionLevel()
        {
            itemNoiseReduction = settings.AddItem("Noise Reduction Level",
                noiseReductionLevelController.NoiseReductionLevelNames, noiseReductionLevelController.Index,
                ChangeNoiseReductionLevel, -2, 0, 160);

            noiseReductionLevelController.OnChange += (index) =>
            {
                itemNoiseReduction.Index = index;
            };

            noiseReductionLevelController.OnUpdateList += (list, index) =>
            {
                itemNoiseReduction.Options = list;
                itemNoiseReduction.Index = index;
            };
        }

        private void ChangeNoiseReductionLevel(int index)
        {
            noiseReductionLevelController.Index = index;
        }
    }
}
