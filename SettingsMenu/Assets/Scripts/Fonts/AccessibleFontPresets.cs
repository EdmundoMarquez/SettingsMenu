using TMPro;


namespace Fragsoft.Fonts
{
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "AccesibleFontPresets", menuName = "Accessibility/FontPresets", order = 0)]
    public class AccessibleFontPresets : ScriptableObject 
    {
        [Header("Font Presets")]
        public TMP_FontAsset SerifFont;
        public TMP_FontAsset SansSerifFont;
        public TMP_FontAsset OpenDyslexicFont;
        [Header("Font Sizes")]
        [Range(20,70)] public float smallSize = 20;
        [Range(20,70)] public float mediumSize = 35;
        [Range(20,70)] public float largeSize = 50;

        public TMP_FontAsset GetFont(int preset)
        {
            switch(preset)
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

        public float GetSize(int size)
        {
            switch(size)
            {
                default:
                case 0:
                    return smallSize;
                case 1:
                    return mediumSize;
                case 2:
                    return largeSize;
            }
            
        }
    }       
}