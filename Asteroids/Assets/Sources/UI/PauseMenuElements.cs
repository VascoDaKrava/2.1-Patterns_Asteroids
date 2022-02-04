using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Asteroids
{
    public sealed class PauseMenuElements : MonoBehaviour, IPointerEnterHandler
    {
        
        #region Fields

        private const string BUTTON_RESUME = "ButtonResume";
        private const string BUTTON_BACK_TO_MENU = "ButtonBackToMenu";

        private event Action _onEnter;

        #endregion


        #region Properties

        public Button ButtonResume { get; private set; }

        public Button ButtonBackToMenu { get; private set; }

        public event Action OnEnter
        {
            add { _onEnter += value; }
            remove { _onEnter -= value; }
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            ButtonResume = GameObject.Find(BUTTON_RESUME).GetComponent<Button>();
            ButtonBackToMenu = GameObject.Find(BUTTON_BACK_TO_MENU).GetComponent<Button>();
        }

        #endregion


        #region IPointerEnterHandler

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerEnter.TryGetComponent(out Selectable pointerEnterObject))
            {
                if (pointerEnterObject.interactable)
                {
                    _onEnter.Invoke();
                }
            }
        }

        #endregion

    }
}
