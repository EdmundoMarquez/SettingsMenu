using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

namespace SettingsMenu
{
    public class GraphicsSettings : MonoBehaviour
    {
        [SerializeField] private CustomDropdown _graphicPresetsDropdown = null;
        [SerializeField] private CustomDropdown _textureQualityDropdown = null;
        // [SerializeField] private CustomDropdown _antiAliasingDropdown = null;

        private void Start() 
        {
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
            _graphicPresetsDropdown.Init(options, 0);
        }

        private void SetCustomQualityDropdowns()
        {
            List<string> options = new List<string>();
            string[] displayModes = Enum.GetNames(typeof(CustomQualityLevels));
              
            foreach(var mode in displayModes)
            {
                options.Add(mode);
            }
            
            _textureQualityDropdown.Init(options, 0);
        }
    }    
}