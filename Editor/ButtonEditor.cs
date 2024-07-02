using UnityEditor;
using UnityEngine;

namespace UtilityToolkit.Editor
{
    [CustomEditor(typeof(MonoBehaviour), true)]
    public class InspectorButtonEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var monoBehaviour = (MonoBehaviour)target;

            // Iterate over all methods in the target class
            var methods = monoBehaviour.GetType().GetMethods(System.Reflection.BindingFlags.Instance |
                                                             System.Reflection.BindingFlags.Public |
                                                             System.Reflection.BindingFlags.NonPublic);
            foreach (var method in methods)
            {
                // Check if the method has the InspectorButtonAttribute
                var attributes = method.GetCustomAttributes(typeof(ButtonAttribute), true);
                foreach (var attribute in attributes)
                {
                    if (attribute is ButtonAttribute buttonAttribute)
                    {
                        var buttonLabel = string.IsNullOrEmpty(buttonAttribute.ButtonLabel) ? method.Name : buttonAttribute.ButtonLabel;

                        if (GUILayout.Button(buttonLabel))
                        {
                            method.Invoke(monoBehaviour, null);
                        }
                    }
                }
            }
        }
    }
}