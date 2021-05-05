using System;
using System.Collections;
using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.Controllers
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private GameData _data;
        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            new GameInit(_controllers, _data);
            _controllers.Initialize();
        }
    }
}

