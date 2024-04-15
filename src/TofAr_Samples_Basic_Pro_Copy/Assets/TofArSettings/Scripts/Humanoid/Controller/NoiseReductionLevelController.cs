/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2023 Sony Semiconductor Solutions Corporation.
 *
 */

using System;
using TofAr.V0.Humanoid;

namespace TofArSettings.Humanoid
{
    public class NoiseReductionLevelController : ControllerBase
    {
        int index;
        public int Index
        {
            get { return index; }
            set
            {
                if (value != index && 0 <= value &&
                    value < NoiseReductionLevelList.Length)
                {
                    index = value;
                    TofArHumanoidManager.Instance.NoiseReductionLevel =
                        NoiseReductionLevelList[value];

                    OnChange?.Invoke(Index);
                }
            }
        }

        public NoiseReductionLevel Level
        {
            get
            {
                return TofArHumanoidManager.Instance.NoiseReductionLevel;
            }

            set
            {
                if (value != Level)
                {
                    Index = Utils.Find(value, NoiseReductionLevelList);
                }
            }
        }

        public NoiseReductionLevel[] NoiseReductionLevelList { get; private set; }

        string[] levelNames = new string[0];
        public string[] NoiseReductionLevelNames
        {
            get { return levelNames; }
        }

        public event ChangeIndexEvent OnChange;

        public event UpdateArrayEvent OnUpdateList;

        protected override void Start()
        {
            

            UpdateList();

            base.Start();
        }

        /// <summary>
        /// Update list
        /// </summary>
        void UpdateList()
        {
            var mgr = TofArHumanoidManager.Instance;

            // Get Process Level list
            NoiseReductionLevelList = (NoiseReductionLevel[])Enum.GetValues(typeof(NoiseReductionLevel));
            levelNames = Enum.GetNames(typeof(NoiseReductionLevel));

            // Get initial values
            index = Utils.Find(mgr.NoiseReductionLevel, NoiseReductionLevelList);
            if (index < 0)
            {
                index = 0;
            }

            OnUpdateList?.Invoke(NoiseReductionLevelNames, Index);
        }
    }
}
