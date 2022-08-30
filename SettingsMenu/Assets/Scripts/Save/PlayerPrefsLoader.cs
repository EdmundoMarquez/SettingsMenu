using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EdsDevExp.Settings;

namespace EdsDevExp.Save
{
    public class PlayerPrefsLoader : MonoBehaviour
    {
        [SerializeField] private SettingsPreferences _defaultPreferences = null;
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
            PreferencesObject preferences = PreferencesFileHandler.Load();

            int resolutionIndex = preferences.resolutionIndex; 
            int targetFps = preferences.targetFps;
            int displayMode = preferences.displayMode;
            bool vSync = (preferences.vSync == 1);

            int graphicsPreset = preferences.graphicsPreset;
            int texturesQuality = preferences.texturesQuality;

            int masterVol = preferences.masterVol;
            int musicVol = preferences.musicVol;
            int sfxVol = preferences.sfxVol;
            int ambientVol = preferences.ambientVol;

            _screenSettings.Init(resolutionIndex, targetFps, (DisplayModes)displayMode, vSync);
            _graphicSettings.Init(graphicsPreset, (CustomQualityLevels)texturesQuality);
            _soundSettings.Init(masterVol, musicVol, sfxVol, ambientVol);
            _fontSettings.Init(preferences.fontPreset, preferences.fontSize);
            _languageSettings.Init(preferences.languageIndex);
            _languageSettings.ChangeLanguage(preferences.languageIndex);
        }

        public void ResetPrefs()
        {
            PreferencesObject preferences = PreferencesFileHandler.Load();

            preferences.resolutionIndex = _defaultPreferences.resolutionIndex;
            preferences.targetFps = _defaultPreferences.targetFps;
            preferences.displayMode = _defaultPreferences.displayMode;
            preferences.vSync = _defaultPreferences.vSync;

            preferences.graphicsPreset = _defaultPreferences.graphicsPreset;
            preferences.texturesQuality = _defaultPreferences.texturesQuality;

            preferences.masterVol = _defaultPreferences.masterVol;
            preferences.musicVol = _defaultPreferences.musicVol;
            preferences.sfxVol = _defaultPreferences.sfxVol;
            preferences.ambientVol = _defaultPreferences.ambientVol;
            
            preferences.languageIndex = _defaultPreferences.languageIndex;
            preferences.fontPreset = _defaultPreferences.fontPreset;
            preferences.fontSize = _defaultPreferences.fontSize;

            PreferencesFileHandler.Save(preferences);
            LoadPrefs();
        }
    }    
}