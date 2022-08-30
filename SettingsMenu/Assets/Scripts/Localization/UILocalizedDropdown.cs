using UnityEngine;
using System.Collections.Generic;
using EdsDevExp.EventBus;
using EdsDevExp.Common;

namespace EdsDevExp.Language
{
    public class UILocalizedDropdown : MonoBehaviour, IEventReceiver<LanguageChanged>
    {
        [SerializeField] private CustomDropdown _customDropdown = null;        

        private void Refresh()
        {
            List<string> options = new List<string>();

            foreach (var option in _customDropdown.Options)
            {
                options.Add(option);
            }

            for (int i = 0; i < options.Count; i++)
            {
                string localizedText = LanguageTextConverter.LoadTitleText(options[i]);
                _customDropdown.Dropdown.options[i].text = localizedText;
            }
            
            _customDropdown.Dropdown.RefreshShownValue();
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