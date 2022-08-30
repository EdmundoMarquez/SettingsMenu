using UnityEngine;
using System.Collections.Generic;

namespace EdsDevExp.Language
{
    public class LanguageStreamLoader : MonoBehaviour
    {
        [SerializeField] private TextAssetData[] _titleTextAssetData = null;
        [SerializeField] private TextAssetData[] _dialogueTextAssetData = null;
        
        private Dictionary<string, TextAsset> _idToTitleAsset;
        private Dictionary<string, TextAsset> _idToDialogueAsset;
       
        private void Awake() 
        {
            _idToTitleAsset = new Dictionary<string, TextAsset>();
            _idToDialogueAsset = new Dictionary<string, TextAsset>();

            for (int i = 0; i < _titleTextAssetData.Length; i++)
            {
                _idToTitleAsset.Add(_titleTextAssetData[i].LanguageId, _titleTextAssetData[i].LanguageAsset);
            }
            // for (int i = 0; i < _dialogueTextAssetData.Length; i++)
            // {
            //     _idToDialogueAsset.Add(_dialogueTextAssetData[i].LanguageId, _dialogueTextAssetData[i].LanguageAsset);
            // }
        }

        public string LoadTitleLanguageData(string languageId)
        {
            
            if(!_idToTitleAsset.TryGetValue(languageId, out var textAsset))
            {
                Debug.LogWarning("Text Asset Data not found");
                return null;
            }
            return textAsset.text;
        }

        public string LoadDialogueLanguageData(string languageId)
        {
            if (!_idToDialogueAsset.TryGetValue(languageId, out var textAsset))
            {
                Debug.LogWarning("Text Asset Data not found");
                return null;
            }
            return textAsset.text;
        }
    }
}
