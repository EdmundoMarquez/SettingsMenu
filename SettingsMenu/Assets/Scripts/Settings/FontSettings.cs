using System.Collections.Generic;
using UnityEngine;
using Fragsoft.EventBus;
using Fragsoft.Common;
using Fragsoft.Fonts;

namespace Fragsoft.Settings
{
    public class FontSettings : MonoBehaviour
    {
        [SerializeField] private CustomDropdown _fontTypeDropdown = null;
        private int _fontPreset;
        private int _fontSize;
        public int FontPreset => _fontPreset;
        public int FontSize => _fontSize;

        public void Init(int fontPreset, int fontSize) 
        {
            _fontPreset = fontPreset;
            _fontSize = fontSize;
            SetFontPresetDropdown();
        }

        private void SetFontPresetDropdown()
        {
            List<string> options = new List<string>();
            options.Add("Serif");
            options.Add("Sans Serif");
            options.Add("Open Dyslexic");
            
            _fontTypeDropdown.Init(options, _fontPreset); 
            SetFontPreset(_fontPreset);
        }

        public void SetFontPreset(int presetIndex)
        {
            _fontPreset = presetIndex;
            EventBus<FontChanged>.Raise(new FontChanged
            {
                fontPreset = presetIndex
            });
        }
    }
}