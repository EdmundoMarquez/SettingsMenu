using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using EdsDevExp.Common;

namespace EdsDevExp.Settings
{
    public class GraphicsSettings : MonoBehaviour
    {
        [SerializeField] private CustomDropdown _graphicPresetsDropdown = null;
        [SerializeField] private DropdownOptions _graphicPresetsOptions = null;
        [SerializeField] private CustomDropdown _textureQualityDropdown = null;
        [SerializeField] private DropdownOptions _textureQualityOptions = null;
        // [SerializeField] private CustomDropdown _antiAliasingDropdown = null;
        private int _graphicsPreset;
        private CustomQualityLevels _texturesQuality;
        public int GraphicsPreset => _graphicsPreset;
        public int TexturesQuality => (int)_texturesQuality;

        public void Init(int graphicPreset, CustomQualityLevels texturesQuality) 
        {
            _graphicsPreset = graphicPreset;
            _texturesQuality = texturesQuality;

            SetGraphicPresetsDropdown();
            SetCustomQualityDropdowns();
        }
        
        public void SetGraphicsPreset(int presetIndex)
        {
            _graphicsPreset = presetIndex;

            if(presetIndex == 5) //not counting custom preset
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
            _texturesQuality = (CustomQualityLevels)qualityIndex;

            _graphicsPreset = 5;
            _graphicPresetsDropdown.Dropdown.value = _graphicsPreset;
        }

        private void SetGraphicPresetsDropdown()
        {
            _graphicPresetsDropdown.Init(_graphicPresetsOptions.Ids, _graphicsPreset);
            SetGraphicsPreset(_graphicsPreset);
        }

        private void SetCustomQualityDropdowns()
        {
            _textureQualityDropdown.Init(_textureQualityOptions.Ids, (int)_texturesQuality);
            SetGraphicsPreset((int)_texturesQuality);
        }
    }    
}