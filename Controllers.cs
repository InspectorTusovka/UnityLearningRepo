using System.Collections.Generic;
using Code.CodeExtentions;
using UnityEngine;

namespace Code.Controllers
{
    internal sealed class Controllers : IInitialize, IOnFrame, IOnLateFrame, IStrictClean, ICleanUp
    {
        private readonly List<IInitialize> _initControllers;
        private readonly List<IOnFrame> _framesControllers;
        private readonly List<IOnLateFrame> _lateFramesControllers;
        private readonly List<IStrictClean> _strictCleanControllers;
        private readonly List<ICleanUp> _cleanUpControllers;


        internal Controllers()
        {
            _initControllers = new List<IInitialize>();
            _framesControllers = new List<IOnFrame>();
            _lateFramesControllers = new List<IOnLateFrame>();
            _strictCleanControllers = new List<IStrictClean>();
            _cleanUpControllers = new List<ICleanUp>();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialize initialize) _initControllers.Add(initialize);
            
            if (controller is IOnFrame frame) _framesControllers.Add(frame);
            
            if (controller is IOnLateFrame lateFrame) _lateFramesControllers.Add(lateFrame);
            
            if (controller is IStrictClean clean) _strictCleanControllers.Add(clean);
            
            if (controller is ICleanUp cleanUp) _cleanUpControllers.Add(cleanUp);

            return this;
        }
        
        public void Initialize()
        {
            foreach (var ctrl in _initControllers)
            {
                ctrl.Initialize();
            }
        }

        public void OnFrame(float deltaTime)
        {
            foreach (var ctrl in _framesControllers)
            {
                ctrl.OnFrame(Time.deltaTime);
            }
        }

        public void OnLateFrame(float deltaTime)
        {
            foreach (var ctrl in _lateFramesControllers)
            {
                ctrl.OnLateFrame(Time.deltaTime);
            }            
        }

        public void StrictCleanUp()
        {
            foreach (var ctrl in _strictCleanControllers)
            {
                ctrl.StrictCleanUp();
            }
        }

        public void CleanUp()
        {
            foreach (var ctrl in _cleanUpControllers)
            {
                ctrl.CleanUp();
            }
        }
    }
}