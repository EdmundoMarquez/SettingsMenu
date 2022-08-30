using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace EdsDevExp.Common
{
    public class CustomDropdown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown = null;
        public TMP_Dropdown Dropdown => _dropdown;
        private List<string> _options = new List<string>();
        public List<string> Options => _options;

        public void Init(List<string> options, int startIndex)
        {
            _options.Clear();

            foreach (var option in options)
            {
                _options.Add(option);
            }

            _dropdown.ClearOptions();
            _dropdown.AddOptions(_options);
            _dropdown.RefreshShownValue();
            _dropdown.SetValueWithoutNotify(startIndex);
        }
    }
}