using UnityEngine;
using System.Linq;

namespace SettingsMenu
{
    public class VideoSettingsController : MonoBehaviour
    {
        [SerializeField] private VideoSettingsView _settingsView = null;
        private Resolution[] _resolutions;
        private int _resolutionIndex;
        private int _refreshRate = 30;

        private void Start() 
        {
            _resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == _refreshRate).ToArray();
            _resolutions = Screen.resolutions.Where(resolution => resolution.height >= 720f).ToArray();

            for (int i = 0; i < _resolutions.Length; i++)
            {
                if (_resolutions[i].width == Screen.currentResolution.width 
                && _resolutions[i].height == Screen.currentResolution.height)
                {
                    _resolutionIndex = i;
                }
            }

            _settingsView.ResolutionIndex = _resolutionIndex;
            _settingsView.Init(_resolutions, _refreshRate);
        }

        public void SetResolution(int resolutionIndex)
        {
            _resolutionIndex = resolutionIndex;
            _settingsView.ResolutionIndex = _resolutionIndex;

            Resolution resolution = _resolutions[_resolutionIndex];
	        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }
        
        public void SetRefreshRate(int refreshRateIndex)
        {
            _refreshRate = refreshRateIndex == 0 ? 30 : 60;

            _resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == _refreshRate).ToArray();
            _resolutions = Screen.resolutions.Where(resolution => resolution.height >= 720f).ToArray();

            SetResolution(_resolutionIndex);
            _settingsView.RefreshResolutions(_resolutions);
        }

        public void SetDisplayMode(int displayModeIndex)
        {
            Screen.fullScreen = displayModeIndex == 1;
        }
    }    
}