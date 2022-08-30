using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdsDevExp.Language
{
    public class LocalizedTextsLoader : MonoBehaviour
    {
        [SerializeField] private UILocalizedText[] _localizedTexts;

        public void Init()
        {
            foreach (var text in _localizedTexts)
            {
                text.Refresh();
            }
        }
    }    
}