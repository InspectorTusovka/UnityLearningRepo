using TMPro;
using UnityEngine;

    namespace Code.Components
    {
        /// <summary>
        /// ViewComponet is View in MVC pattern
        /// </summary>
        public class ViewComponent : MonoBehaviour
        {
            [SerializeField] private TMP_Text bulletsInfo;
            [SerializeField] private TMP_Text screenMessage;
        
            public string BulletsInfo
            {
                set => bulletsInfo.text = value;
            }

            public string ScreenMessage
            {
                set => screenMessage.text = value;
            }
        }
    }