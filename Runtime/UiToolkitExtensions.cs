using UnityEngine.UIElements;

namespace UtilityToolkit.Runtime
{
    public static class UiToolkitExtensions
    {
        public static void Show(this VisualElement element)
        {
            element.style.display = DisplayStyle.Flex;
        }
        
        public static void Hide(this VisualElement element)
        {
            element.style.display = DisplayStyle.None;
        }
    }
}