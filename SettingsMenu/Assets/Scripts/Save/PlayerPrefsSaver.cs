using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fragsoft.Settings;

namespace Fragsoft.Save
{
    public class PlayerPrefsSaver: MonoBehaviour
    {
        [SerializeField] private SettingsPreferences _savedPreferences = null;
        [SerializeField] private ScreenSettings _screenSettings = null;
        [SerializeField] private GraphicsSettings _graphicSettings = null;
        [SerializeField] private SoundSettings _soundSettings = null;
        [SerializeField] private LanguageSettings _languageSettings = null;
        [SerializeField] private FontSettings _fontSettings = null;

        public void SavePrefs() 
        {
            _savedPreferences.resolutionIndex = _screenSettings.ResolutionIndex;
            _savedPreferences.targetFps = _screenSettings.TargetFps;
            _savedPreferences.displayMode = _screenSettings.DisplayMode;
            _savedPreferences.vSync = _screenSettings.VSync;

            _savedPreferences.graphicsPreset = _graphicSettings.GraphicsPreset;
            _savedPreferences.texturesQuality = _graphicSettings.TexturesQuality;

            _savedPreferences.masterVol = _soundSettings.MasterVol;
            _savedPreferences.musicVol = _soundSettings.MusicVol;
            _savedPreferences.sfxVol = _soundSettings.SfxVol;
            _savedPreferences.ambientVol = _soundSettings.AmbientVol;
            
            _savedPreferences.languageIndex = _languageSettings.LanguageIndex;
            _savedPreferences.fontPreset = _fontSettings.FontPreset;
            _savedPreferences.fontSize = _fontSettings.FontSize;
        }
    }    
}
