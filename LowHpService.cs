using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.CodeExtensions
{
    [Serializable]
    public class LowHpService : MonoBehaviour
    {
        private AudioSource _playerMusic;
        [SerializeField] private Image crosshair;

        private void Start()
        {
            _playerMusic = GetComponent<AudioSource>();
        }

        public void MusicSpeedBoost()
        {
            _playerMusic.volume = 1f;
            _playerMusic.pitch = 0.75f;
        }

        public void CrosshairColorChange()
        {
            crosshair.color = Color.red;
        }
    }
}