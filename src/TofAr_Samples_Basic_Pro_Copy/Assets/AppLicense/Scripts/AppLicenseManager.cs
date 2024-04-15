/*
 * SPDX-License-Identifier: (Apache-2.0 OR GPL-2.0-only)
 *
 * Copyright 2022,2023 Sony Semiconductor Solutions Corporation.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TofAr.AppLicense
{
    public class AppLicenseManager : MonoBehaviour
    {
        private const string license_title = "License information";

        private const string license_fileName = "license";

        private const string agree_key = "AGREEKEY";

        private AppLicense appLicense;

        public GameObject baseButtonPrefab;
        public GameObject borderPrefab;

        public GameObject scrollTextViewPrefab;

        private string licenseText;

        void Awake()
        {
            SetCaller();
        }

        void Start()
        {
            //Debug : Reset Check
            //PlayerPrefs.DeleteAll();
            licenseText = "";

            CheckAgreeView();
            ImportTextsFromFile();
            SetButtons();
        }

        public void SetCaller()
        {
            AppLicense[] appLicense = FindObjectsOfType<AppLicense>();

            if (appLicense.Length > 0)
            {
                this.appLicense = appLicense[0];
            }
        }

        private void CheckAgreeView()
        {
            appLicense.SetAgreeState(true);
        }

        public void AgreeStartButton()
        {
            PlayerPrefs.SetInt(agree_key, 1);
            PlayerPrefs.Save();

            appLicense.SetAgreeState(true);
        }

        private void ImportTextsFromFile()
        {
            Debug.Log("importing text files");
            licenseText = TextImporter.MergeImport(license_fileName);
        }

        private void SetButtons()
        {
            if (appLicense.buttonParent != null)
            {
                Instantiate(borderPrefab, appLicense.buttonParent.transform);

                GameObject licenseButton = Instantiate(baseButtonPrefab, appLicense.buttonParent.transform);
                SettingButton(licenseButton, license_title, LicenseView);
            }
        }

        private void SettingButton(GameObject button, string title, UnityAction unityAction)
        {
            button.GetComponentInChildren<Text>().text = title;
            button.GetComponent<Button>().onClick.AddListener(unityAction);
        }

        public void LicenseView()
        {
            SetScrollTextView(license_title, licenseText);
        }

        private void SetScrollTextView(string title, string msg)
        {
            GameObject scrollTextView = Instantiate(scrollTextViewPrefab, appLicense.agreeViewParent.transform);
            scrollTextView.GetComponent<ScrollTextView>().SetText(title, msg);
        }
    }
}
