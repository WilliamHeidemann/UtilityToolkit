using System;
using UnityEngine;

namespace UtilityToolkit.Editor
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string ButtonLabel { get; }

        public ButtonAttribute(string buttonLabel = null)
        {
            ButtonLabel = buttonLabel;
        }
    }
}