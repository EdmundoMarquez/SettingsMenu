using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EdsDevExp.Settings;

namespace EdsDevExp.Save
{
    public class PlayerPrefsSaver: MonoBehaviour
    {
        [SerializeField] private ScreenSettings _screenSettings = null;
        [SerializeField] private GraphicsSettings _graphicSettings = null;
        [SerializeField] private SoundSettings _soundSettings = null;
        [SerializeField] private LanguageSettings _languageSettings = null;
        [SerializeField] private FontSettings _fontSettings = null;

        public void SavePrefs() 
        {
            PreferencesObject preferences = new PreferencesObject();

            preferences.resolutionIndex = _screenSettings.ResolutionIndex;
            preferences.targetFps = _screenSettings.TargetFps;
            preferences.displayMode = _screenSettings.DisplayMode;
            preferences.vSync = _screenSettings.VSync;

            preferences.graphicsPreset = _graphicSettings.GraphicsPreset;
            preferences.texturesQuality = _graphicSettings.TexturesQuality;

            preferences.masterVol = _soundSettings.MasterVol;
            preferences.musicVol = _soundSettings.MusicVol;
            preferences.sfxVol = _soundSettings.SfxVol;
            preferences.ambientVol = _soundSettings.AmbientVol;
            
            preferences.languageIndex = _languageSettings.LanguageIndex;
            preferences.fontPreset = _fontSettings.FontPreset;
            preferences.fontSize = _fontSettings.FontSize;

            PreferencesFileHandler.Save(preferences);
        }
    }    
}
