using System.Collections.Generic;
using UnityEngine;
using Fragsoft.EventBus;
using Fragsoft.Common;

namespace Fragsoft.Settings
{
    public class FontSettings : MonoBehaviour
    {
        [SerializeField] private CustomDropdown _fontPresetDropdown = null;
        [SerializeField] private DropdownOptions _fontPresetOptions = null;
        [SerializeField] private CustomDropdown _fontSizeDropdown = null;
        [SerializeField] private DropdownOptions _fontSizeOptions = null;
        private int _fontPreset;
        private int _fontSize;
        public int FontPreset => _fontPreset;
        public int FontSize => _fontSize;

        public void Init(int fontPreset, int fontSize) 
        {
            _fontPreset = fontPreset;
            _fontSize = fontSize;
            SetFontPresetDropdown();
            SetFontSizeDropdown();
        }

        private void SetFontPresetDropdown()
        {
            _fontPresetDropdown.Init(_fontPresetOptions.Ids, _fontPreset); 
            SetFontPreset(_fontPreset);
        }

        private void SetFontSizeDropdown()
        {
            _fontSizeDropdown.Init(_fontSizeOptions.Ids, _fontSize); 
            SetFontSize(_fontSize);
        }

        public void SetFontPreset(int presetIndex)
        {
            _fontPreset = presetIndex;
            EventBus<FontChanged>.Raise(new FontChanged
            {
                fontPreset = presetIndex,
                fontSize = _fontSize
            });
        }

        public void SetFontSize(int sizeIndex)
        {
            _fontSize = sizeIndex;
            EventBus<FontChanged>.Raise(new FontChanged
            {
                fontPreset = _fontPreset,
                fontSize = _fontSize
            });
        }
    }
}