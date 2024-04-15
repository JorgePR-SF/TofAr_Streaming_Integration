/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2023 Sony Semiconductor Solutions Corporation.
 *
 */

using System.Collections.Generic;
using TofArSamples.Body;
using TofArSamples.Hand;
using UnityEngine.Events;
using UI = TofArSettings.UI;

namespace TofArSamples.Humanoid
{
    public class HumanoidViewSettings : ImageViewSettings
    {
        protected UI.ItemToggle itemShowHandBones, itemApplyHipMotion;
        protected UI.ItemDropdown itemBodyModel;

        protected UI.ItemToggle itemShowHand, itemShowBody, itemShowFace;

        SkeletonHandController skeletonCtrl;
        BodyModelController bodyModelCtrl;
        TofAr.V0.Tof.SkeletonDepthView skeletonDepthView;

        protected override void Awake()
        {
            base.Awake();
            skeletonCtrl = GetComponent<SkeletonHandController>();
            controllers.Add(skeletonCtrl);
            bodyModelCtrl = FindObjectOfType<BodyModelController>();
            controllers.Add(bodyModelCtrl);

            skeletonDepthView = FindObjectOfType<TofAr.V0.Tof.SkeletonDepthView>();

            uiOrder = new UnityAction[0];
        }

        /// <summary>
        /// Prepare for UI creation
        /// </summary>
        protected override void PrepareUI()
        {
            base.PrepareUI();

            var list = new List<UnityAction>(uiOrder);
            list.Add(MakeUIShowHandBones);
            list.Add(MakeUIShowBodyBones);

            list.Add(MakeUISkeletonDepthView);

            // Set UI order
            uiOrder = list.ToArray();
        }

        private void MakeUISkeletonDepthView()
        {
            itemShowHand = settings.AddItem("Show Hand 2D", skeletonDepthView.ShowHand, (bool onOff) =>
            {
                skeletonDepthView.ShowHand = onOff;
            });

            itemShowBody = settings.AddItem("Show Body 2D", skeletonDepthView.ShowBody, (bool onOff) =>
            {
                skeletonDepthView.ShowBody = onOff;
            });

            itemShowFace = settings.AddItem("Show Face 2D", skeletonDepthView.ShowFace, (bool onOff) =>
            {
                skeletonDepthView.ShowFace = onOff;
            });
        }

        private void MakeUIShowHandBones()
        {
            itemShowHandBones = settings.AddItem("Show Hand Bones", skeletonCtrl.IsShow, ChangeShowHandBones);

            skeletonCtrl.OnChangeShow += (onOff) =>
            {
                itemShowHandBones.OnOff = onOff;
            };
        }

        /// <summary>
        /// Change ShowHand Bones State
        /// </summary>
        void ChangeShowHandBones(bool onOff)
        {
            skeletonCtrl.IsShow = onOff;
        }

        private void MakeUIShowBodyBones()
        {
            itemBodyModel = settings.AddItem("Body Model", bodyModelCtrl.ModelNames,
                bodyModelCtrl.Index, ChangeBodyModel);

            bodyModelCtrl.OnChangeIndex += (index) =>
            {
                itemBodyModel.Index = index;
            };
        }

        /// <summary>
        /// Change ShowHand Bones State
        /// </summary>
        void ChangeBodyModel(int index)
        {
            bodyModelCtrl.Index = index;
        }
    }
}
