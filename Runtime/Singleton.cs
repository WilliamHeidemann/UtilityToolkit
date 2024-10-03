using System;
using UnityEngine;

namespace UtilityToolkit.Runtime
{
    public class Singleton<T> where T : new()
    {
        public static readonly T Instance = new();
        protected Singleton() {}
    }
}