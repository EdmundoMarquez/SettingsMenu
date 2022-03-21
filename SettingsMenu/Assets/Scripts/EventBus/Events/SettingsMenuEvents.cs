using UnityEngine;
namespace Fragsoft.EventBus
{
    public struct FontChanged : IEvent 
    {
        public int fontPreset;
    }
    public struct LanguageChanged : IEvent {}
}
