using System;
using UnityEngine;

namespace UtilityToolkit.Runtime
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Instance of {typeof(T)} already exists.");
                return;
            }

            Instance = this as T;
        }
    }
}