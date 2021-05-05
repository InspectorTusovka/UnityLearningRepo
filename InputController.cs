using Code.CodeExtentions;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class InputController : IOnFrame, IInitialize
    {
        private Axis axis;
        
        public void Initialize()
        {
            axis.Horizontal = 0;
            axis.Vertical = 0;
        }

        public Axis GetInput()
        {
            return axis;
        }

        internal struct Axis
        {
            internal float Horizontal;
            internal float Vertical;
        }

        public void OnFrame(float deltaTime)
        {
            axis.Horizontal = Input.GetAxis("Horizontal");
            axis.Vertical  = Input.GetAxis("Vertical");
        }
    }
}