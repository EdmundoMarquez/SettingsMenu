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
        private int _languageIndex;
        public int LanguageIndex => _languageIndex;

        public void Init(int languageIndex) 
        {
            _languageIndex = languageIndex;
            SetLanguagesDropdown();
        }

        private void SetLanguagesDropdown()
        {
            List<string> options = new List<string>();

            foreach(var language in _supportedLanguages)
            {
                options.Add(language.LanguageId);
            }
            
            _languageDropdown.Init(options, _languageIndex);
        }

        public void ChangeLanguage(int languageIndex)
        {
            _languageIndex = languageIndex;

            string id = _supportedLanguages[languageIndex].LanguageId;
            _languageConverter.ChangeLanguage(id);
        }
    }    
}