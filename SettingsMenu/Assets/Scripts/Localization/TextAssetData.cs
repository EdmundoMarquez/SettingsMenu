using UnityEngine;

namespace SettingsMenu.Language
{
    
    [CreateAssetMenu(fileName = "Text Asset Data", menuName = "Language/Text Asset Data", order = 0)]
    public class TextAssetData : ScriptableObject 
    {
        [SerializeField] private string _languageId = null;
        [SerializeField] private TextAsset _languageAsset = null;

        public string LanguageId  => _languageId;
        public TextAsset LanguageAsset => _languageAsset;
    }
}
