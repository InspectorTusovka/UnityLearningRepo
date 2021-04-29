using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.CodeExtensions
    {
        /// <summary>
        /// ViewComponet is View in MVC pattern
        /// </summary>
        public class ViewComponent : MonoBehaviour
        {
            [SerializeField] private TMP_Text bulletsInfo;
            [SerializeField] private TMP_Text screenMessage;
            [SerializeField] private Image healthBar;
        
            public string BulletsInfo
            {
                set => bulletsInfo.text = value;
            }

            public string ScreenMessage
            {
                set => screenMessage.text = value;
            }

            public float HealthBarFill
            {
                get => healthBar.fillAmount;
                set => healthBar.fillAmount = value;
            }
        }
    }