using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace EdsDevExp.Settings
{
    public class SettingsTabChanger : MonoBehaviour
    {
        [SerializeField] private Button[] _tabButtons;
        [SerializeField] private CanvasGroup _displayTab = null;
        [SerializeField] private CanvasGroup _soundsTab = null;
        [SerializeField] private CanvasGroup _accessibilityTab = null;

        private void Start() 
        {
            ChangeTab(0);    
        }

        public void ChangeTab(int tabIndex)
        {
            for (int i = 0; i < _tabButtons.Length; i++)
            {
                _tabButtons[i].interactable = (i != tabIndex);
            }

            switch(tabIndex)
            {
                default:
                case 0:
                    Show(_displayTab);
                    Hide(_soundsTab);
                    Hide(_accessibilityTab);
                    break;
                case 1:
                    Show(_soundsTab);
                    Hide(_displayTab);
                    Hide(_accessibilityTab);
                    break;
                case 2:
                    Show(_accessibilityTab);
                    Hide(_displayTab);
                    Hide(_soundsTab);
                    break;
            }
        }

        public void Show(CanvasGroup tab)
        {
            tab.DOFade(1f, 0.2f);
            tab.blocksRaycasts = true;
            tab.interactable = true;
        }

        public void Hide(CanvasGroup tab)
        {
            tab.DOFade(0f, 0.2f);
            tab.blocksRaycasts = false;
            tab.interactable = false;
        }
    }    
}