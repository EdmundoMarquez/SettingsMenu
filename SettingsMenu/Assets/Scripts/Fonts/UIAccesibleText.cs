using UnityEngine;
using Fragsoft.EventBus;
using TMPro;

namespace Fragsoft.Fonts
{
    public class UIAccesibleText : MonoBehaviour, IEventReceiver<FontChanged>
    {
        [SerializeField] private AccessibleFontPresets _fontPresets;
        [SerializeField] private TMP_Text _text;

        public void OnEvent(FontChanged e)
        {
            _text.font = _fontPresets.GetFont(e.fontPreset);
        }

        private void OnEnable() 
        {
            EventBus<FontChanged>.Register(this);    
        }

        private void OnDisable() 
        {
            EventBus<FontChanged>.UnRegister(this);    
        }
    }    
}