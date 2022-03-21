using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using Fragsoft.Common;

namespace Fragsoft.Settings
{
    public class GraphicsSettings : MonoBehaviour
    {
        [SerializeField] private CustomDropdown _graphicPresetsDropdown = null;
        [SerializeField] private CustomDropdown _textureQualityDropdown = null;
        // [SerializeField] private CustomDropdown _antiAliasingDropdown = null;
        private int _graphicPreset;
        private CustomQualityLevels _texturesQuality;
        public int GraphicsPreset => _graphicPreset;
        public int TexturesQuality => (int)_texturesQuality;

        public void Init(int graphicPreset, CustomQualityLevels texturesQuality) 
        {
            _graphicPreset = graphicPreset;
            _texturesQuality = texturesQuality;

            SetGraphicPresetsDropdown();
            SetCustomQualityDropdowns();
        }
        
        public void SetGraphicsPreset(int presetIndex)
        {
            if(presetIndex == 6) //not counting custom preset
            {
                return;
            }
                
            QualitySettings.SetQualityLevel(presetIndex);
            TMP_Dropdown textureDropdown = _textureQualityDropdown.Dropdown;

            if(presetIndex >= 3) //if preset is above high
            {   
                textureDropdown.SetValueWithoutNotify((int)CustomQualityLevels.High);
            } 
            else if(presetIndex <= 1) //if preset is below medium
            {
                textureDropdown.SetValueWithoutNotify((int)CustomQualityLevels.Low);
            }
            else //if preset is medium
            {
                textureDropdown.SetValueWithoutNotify((int)CustomQualityLevels.Mid);
            }
        }

        public void SetTextureQuality(int qualityIndex)
        {
            QualitySettings.masterTextureLimit = qualityIndex;
            _graphicPresetsDropdown.Dropdown.value = 6;
        }

        private void SetGraphicPresetsDropdown()
        {
            List<string> options = new List<string>();

            foreach(var preset in QualitySettings.names)
            {
                options.Add(preset);
            }
            options.Add("Custom");
            _graphicPresetsDropdown.Init(options, _graphicPreset);
            
            SetGraphicsPreset(_graphicPreset);
        }

        private void SetCustomQualityDropdowns()
        {
            List<string> options = new List<string>();
            string[] displayModes = Enum.GetNames(typeof(CustomQualityLevels));
              
            foreach(var mode in displayModes)
            {
                options.Add(mode);
            }
            
            _textureQualityDropdown.Init(options, (int)_texturesQuality);
            SetGraphicsPreset((int)_texturesQuality);
        }
    }    
}