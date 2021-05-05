using UnityEngine;

namespace Code.CodeExtentions
{
    internal interface IOnFrame : IController
    {
        void OnFrame(float deltaTime);
    }
}