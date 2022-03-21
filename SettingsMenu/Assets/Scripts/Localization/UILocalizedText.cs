using UnityEngine;
using TMPro;
using Fragsoft.EventBus;

namespace Fragsoft.Language
{
    public class UILocalizedText : MonoBehaviour, IEventReceiver<LanguageChanged>
    {
        [SerializeField] private string _textId;
        [SerializeField] private TextMeshProUGUI _text;

        public void Refresh() 
        {
            string text = LanguageTextConverter.LoadTitleText(_textId);
            _text.text = text; 
            Debug.Log(text);
        }

        public void OnEvent(LanguageChanged e)
        {
            Refresh();
        }

        private void OnEnable() 
        {
            EventBus<LanguageChanged>.Register(this);    
        }

        private void OnDisable() 
        {
            EventBus<LanguageChanged>.UnRegister(this);    
        }
    }    
}