using UnityEngine;

namespace EdsDevExp.Save
{
    [CreateAssetMenu(fileName = "Saved Preferences", menuName = "Settings/SavedPreferences", order = 0)]
    public class SettingsPreferences : ScriptableObject
    {
        [Header("Screen")]
        public int resolutionIndex = -1;
        public int displayMode = 1;
        public int targetFps = 1;
        public int vSync = 0;
        [Header("Graphics")]
        public int graphicsPreset = 5;
        public int texturesQuality = 2;
        [Header("Audio")]
        public int masterVol = -5;
        public int musicVol = -5;
        public int sfxVol = -5;
        public int ambientVol = -5;
        [Header("Language")]
        public int languageIndex = 0;
        public int fontPreset = 1;
        public int fontSize = 1;
    }
}