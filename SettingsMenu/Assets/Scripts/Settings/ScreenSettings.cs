using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Collections.Generic;
using Fragsoft.Common;

namespace Fragsoft.Settings
{
    public class ScreenSettings : MonoBehaviour
    {
        [SerializeField] private  CustomDropdown _resolutionDropdown = null;
        [SerializeField] private  CustomDropdown _targetFpsDropdown = null;
        [SerializeField] private  CustomDropdown _displayModeDropdown = null;
        [SerializeField] private Toggle _vSyncToggle = null;
        private int _refreshRate = 60;
        private Resolution[] _resolutions;
        private int _resolutionIndex;
        private int _targetFps;
        private DisplayModes _displayMode;
        private bool _vSync;
        public int ResolutionIndex => _resolutionIndex;
        public int TargetFps => _targetFps;
        public int DisplayMode => (int)_displayMode;
        public int VSync => _vSync ? 1 : 0;

        public void Init(int resolutionIndex, int targetFps, DisplayModes displayMode,  bool vSync)
        {
            _resolutionIndex = resolutionIndex;
            _targetFps = targetFps;
            _displayMode = displayMode;
            _vSync = vSync;

            _resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == _refreshRate).ToArray();
            _resolutions = Screen.resolutions.Where(resolution => resolution.height >= 720f).ToArray();

            if(_resolutionIndex < 0) //set default native resolution
            {
                for (int i = 0; i < _resolutions.Length; i++)
                {
                    if (_resolutions[i].width == Screen.currentResolution.width 
                    && _resolutions[i].height == Screen.currentResolution.height)
                    {
                        _resolutionIndex = i;
                    }
                }
            }

            SetResolutionsDropdown();
            SetTargetFpsDropdown();
            SetDisplayModesDropdown();
            
            _vSyncToggle.SetIsOnWithoutNotify(_vSync);
            SetVSync(vSync);
        }

        public void SetResolution(int resolutionIndex)
        {
            _resolutionIndex = resolutionIndex;

            Resolution resolution = _resolutions[_resolutionIndex];
	        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        
        public void SetTargetFps(int fpsTargetIndex)
        {
            _targetFps = fpsTargetIndex == 0 ? 30 : 60;
            Application.targetFrameRate = _targetFps;
        }

        public void SetDisplayMode(int displayModeIndex)
        {
            _displayMode = (DisplayModes) displayModeIndex;
            Screen.fullScreen = displayModeIndex == 1;
        }

        public void SetVSync(bool vSyncOn)
        {
            _vSync = vSyncOn;
            QualitySettings.vSyncCount = vSyncOn ? 1 : 0;
        }

        public void SetResolutionsDropdown()
        {
            List<string> options = new List<string>();
            
            for (int i = 0; i < _resolutions.Length; i++)
            {
	            string option = _resolutions[i].width + " x " + _resolutions[i].height;
	            options.Add(option);
            }

            _resolutionDropdown.Init(options, _resolutionIndex);
            SetResolution(_resolutionIndex);
        }

        private void SetTargetFpsDropdown()
        {
            List<string> options = new List<string>();
            options.Add("30");
            options.Add("60");
            
            _targetFpsDropdown.Init(options, _targetFps); 
            SetTargetFps(_targetFps);
        }

        private void SetDisplayModesDropdown()
        {
            List<string> options = new List<string>();
            string[] displayModes = Enum.GetNames(typeof(DisplayModes));
              
            foreach(var mode in displayModes)
            {
                options.Add(mode);
            }
            
            _displayModeDropdown.Init(options, (int)_displayMode);
            SetDisplayMode((int)_displayMode);
        }
    }    
}