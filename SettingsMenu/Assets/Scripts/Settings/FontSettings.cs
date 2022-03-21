using System.Collections.Generic;
using UnityEngine;
using Fragsoft.EventBus;
using Fragsoft.Common;
using Fragsoft.Fonts;

namespace Fragsoft.Settings
{
    public class FontSettings : MonoBehaviour
    {
        [SerializeField] private AccessibleFontPresets _fontPresets = null;
        [SerializeField] private CustomDropdown _fontTypeDropdown = null;

        private void Start() 
        {
            SetFontPresetDropdown();
        }

        private void SetFontPresetDropdown()
        {
            List<string> options = new List<string>();
            options.Add("Serif");
            options.Add("Sans Serif");
            options.Add("Open Dyslexic");
            
            _fontTypeDropdown.Init(options, _fontPresets.FixedPreset); 
        }

        public void SetFontPreset(int presetIndex)
        {
            _fontPresets.FixedPreset = presetIndex;
            EventBus<FontChanged>.Raise(new FontChanged{});
        }
    }
}