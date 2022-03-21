using UnityEngine;
namespace Fragsoft.EventBus
{
    public struct FontChanged : IEvent 
    {
        public int fontPreset;
        public int fontSize;
    }
    public struct LanguageChanged : IEvent {}
}
