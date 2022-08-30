using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using EdsDevExp.EventBus;

namespace EdsDevExp.Language
{
    [DefaultExecutionOrder(-1)]
    public class LanguageTextConverter : MonoBehaviour
    {
        [SerializeField] private LanguageStreamLoader _localizationLoader;
        private static Dictionary<string, string> _idToTileText;
        private static Dictionary<string, string> _idToDialogueText;
        public static LanguageTextConverter Instance;
        private string _currentLanguage;
        private static bool _isInitialized = false;

        private void Start()
        {
            if (_isInitialized) return;
            _isInitialized = true;
            _idToTileText = new Dictionary<string, string>();
            _idToDialogueText = new Dictionary<string, string>();
            _currentLanguage = "";
            Instance = this;
        }
        public static string LoadTitleText(string textId)
        {
            
            if (!_idToTileText.TryGetValue(textId, out string text))
            {
                Debug.LogWarning("Localized text not found");
                return null;
            }
            return text;
        }
        public static string LoadDialogueText(string textId)
        {
            if (!_idToDialogueText.TryGetValue(textId, out string text))
            {
                Debug.LogWarning("Localized text not found");
                return null;
            }
            return text;
        }
        public void ChangeLanguage(string languageId)
        {
            if(_currentLanguage.Equals(languageId))
            {
                EventBus<LanguageChanged>.Raise(new LanguageChanged{});
                return;
            } 
            _currentLanguage = languageId;
            var json = _localizationLoader.LoadTitleLanguageData(languageId);
            _idToTileText.Clear();
            _idToTileText = DeserializeTextData(json);

            // _idToDialogueText.Clear();
            // json = _localizationLoader.LoadDialogueLanguageData(languageId);
            // _idToDialogueText = DeserializeTextData(json);

            EventBus<LanguageChanged>.Raise(new LanguageChanged{});
            Debug.Log($"Language changed to {languageId}");
        }
        public static void SetInitialLanguage(string languageId)
        {
            Instance.ChangeLanguage(languageId);
        }

        private Dictionary<string, string> DeserializeTextData(string json)
        {
            Dictionary<string, string> deserializeDictionary = new Dictionary<string, string>();
            deserializeDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return deserializeDictionary;
        }
    }
}
