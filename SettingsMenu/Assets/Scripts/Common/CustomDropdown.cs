using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace Fragsoft.Common
{
    public class CustomDropdown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown = null;
        public TMP_Dropdown Dropdown => _dropdown;

        public void Init(List<string> options, int startIndex)
        {
            _dropdown.ClearOptions();
            _dropdown.AddOptions(options);
            _dropdown.RefreshShownValue();
            _dropdown.SetValueWithoutNotify(startIndex);
        }
    }
}