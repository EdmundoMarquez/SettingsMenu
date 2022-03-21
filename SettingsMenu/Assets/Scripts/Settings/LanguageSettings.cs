using UnityEngine;
using TMPro;
using Fragsoft.Language;
using System.Collections.Generic;
using Fragsoft.Common;

namespace Fragsoft.Settings
{
    public class LanguageSettings : MonoBehaviour
    {
        [SerializeField] private TextAssetData[] _supportedLanguages = null;
        [SerializeField] private LanguageTextConverter _languageConverter = null;
        [SerializeField] private CustomDropdown _languageDropdown = null;

        private void Start() 
        {
            SetLanguagesDropdown();
        }

        private void SetLanguagesDropdown()
        {
            List<string> options = new List<string>();

            foreach(var language in _supportedLanguages)
            {
                options.Add(language.name);
            }
            
            _languageDropdown.Init(options, 0);
        }

        public void ChangeLanguage(int languageIndex)
        {
            string id = _supportedLanguages[languageIndex].LanguageId;
            _languageConverter.ChangeLanguage(id);
        }
    }    
}