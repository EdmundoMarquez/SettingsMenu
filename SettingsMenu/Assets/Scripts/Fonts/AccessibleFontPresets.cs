using TMPro;


namespace Fragsoft.Fonts
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "AccesibleFontPresets", menuName = "Accessibility/FontPresets", order = 0)]
    public class AccessibleFontPresets : ScriptableObject 
    {
        public int FixedPreset = 1;
        public float FixedSize = 35;
        [Header("Font Presets")]
        public TMP_FontAsset SerifFont;
        public TMP_FontAsset SansSerifFont;
        public TMP_FontAsset OpenDyslexicFont;
        [Header("Font Sizes")]
        [Range(5,20)] public float smallSize = 20;
        [Range(20,35)] public float mediumSize = 35;
        [Range(35,50)] public float largeSize = 50;

        public TMP_FontAsset GetFont()
        {
            switch(FixedPreset)
            {
                default:
                case 0:
                    return SerifFont;
                case 1:
                    return SansSerifFont;
                case 2:
                    return OpenDyslexicFont;
            }
        }
    }       
}