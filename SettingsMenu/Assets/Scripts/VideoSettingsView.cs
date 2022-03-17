using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

namespace SettingsMenu
{
    public class VideoSettingsView : MonoBehaviour
    {
        [SerializeField] private  TMP_Dropdown _resolutionDropdown = null;
        [SerializeField] private  TMP_Dropdown _refreshRateDropdown = null;
        [SerializeField] private  TMP_Dropdown _displayModeDropdown = null;
        private List<string> options = new List<string>();
        [HideInInspector]
        public int ResolutionIndex;

        public void Init(Resolution[] resolutions, int refreshRate)
        {
            RefreshResolutions(resolutions);
            SetRefreshRatesDropdown();
            SetDisplayModesDropdown();

            _resolutionDropdown.SetValueWithoutNotify(ResolutionIndex);
            
        }

        public void RefreshResolutions(Resolution[] resolutions)
        {
            _resolutionDropdown.ClearOptions();
            List<string> options = new List<string>();
            
            for (int i = 0; i < resolutions.Length; i++)
            {
	            string option = resolutions[i].width + " x " + resolutions[i].height;
	            options.Add(option);
	            
            }

            _resolutionDropdown.AddOptions(options);
            _resolutionDropdown.RefreshShownValue();
            _resolutionDropdown.SetValueWithoutNotify(ResolutionIndex);
        }

        private void SetRefreshRatesDropdown()
        {
            options.Clear();

            options.Add("30");
            options.Add("60");
            
            _refreshRateDropdown.ClearOptions();
            _refreshRateDropdown.AddOptions(options);
        }

        private void SetDisplayModesDropdown()
        {
            options.Clear();
            string[] displayModes = Enum.GetNames(typeof(DisplayModes));
              
            foreach(var mode in displayModes)
            {
                options.Add(mode);
            }
            _displayModeDropdown.ClearOptions();
            _displayModeDropdown.AddOptions(options);
        }
    }
}