using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fragsoft.Settings;

namespace Fragsoft.Save
{
    public class PlayerPrefsLoader : MonoBehaviour
    {
        [SerializeField] private SettingsPreferences _savedPreferences = null;
        [SerializeField] private ScreenSettings _screenSettings = null;
        [SerializeField] private GraphicsSettings _graphicSettings = null;
        [SerializeField] private SoundSettings _soundSettings = null;
        [SerializeField] private LanguageSettings _languageSettings = null;
        [SerializeField] private FontSettings _fontSettings = null;

        private void Start() 
        {
            LoadPrefs();    
        }

        public void LoadPrefs()
        {
            int resolutionIndex = _savedPreferences.resolutionIndex; 
            int targetFps = _savedPreferences.targetFps;
            int displayMode = _savedPreferences.displayMode;
            bool vSync = _savedPreferences.vSync == 1;

            int graphicsPreset = _savedPreferences.graphicsPreset;
            int texturesQuality = _savedPreferences.texturesQuality;

            int masterVol = _savedPreferences.masterVol;
            int musicVol = _savedPreferences.musicVol;
            int sfxVol = _savedPreferences.sfxVol;
            int ambientVol = _savedPreferences.ambientVol;

            _screenSettings.Init(resolutionIndex, targetFps, (DisplayModes)displayMode, vSync);
            _graphicSettings.Init(graphicsPreset, (CustomQualityLevels)texturesQuality);
            _soundSettings.Init(masterVol, musicVol, sfxVol, ambientVol);
            _fontSettings.Init(_savedPreferences.fontPreset, _savedPreferences.fontSize);
            _languageSettings.Init(_savedPreferences.languageIndex);
            _languageSettings.ChangeLanguage(_savedPreferences.languageIndex);
        }

        public void ResetPrefs()
        {
            _savedPreferences.resolutionIndex = -1;
            _savedPreferences.targetFps = 1;
            _savedPreferences.displayMode = 1;
            _savedPreferences.vSync = 0;

            _savedPreferences.graphicsPreset = 4;
            _savedPreferences.texturesQuality = 3;

            _savedPreferences.masterVol = -5;
            _savedPreferences.musicVol = -5;
            _savedPreferences.sfxVol = -5;
            _savedPreferences.ambientVol = -5;
            
            _savedPreferences.languageIndex = 0;
            _savedPreferences.fontPreset = 1;
            _savedPreferences.fontSize = 1;

            LoadPrefs();
        }
    }    
}