using System;
using UnityEngine;

namespace Code.CodeExtensions
{
    public abstract class Collectable : MonoBehaviour, IDisposable
    {
        public abstract void Collect();
        public abstract void Dispose();
    }
}