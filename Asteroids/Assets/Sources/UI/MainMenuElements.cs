using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Asteroids
{
    public sealed class MainMenuElements : MonoBehaviour, IPointerEnterHandler
    {

        #region Fields

        private const string BUTTON_START = "ButtonStart";
        private const string BUTTON_OPTIONS = "ButtonOptions";
        private const string BUTTON_EXIT = "ButtonExit";

        private event Action _onEnter;

        #endregion


        #region Properties

        public Button ButtonStart { get; private set; }

        public Button ButtonOptions { get; private set; }

        public Button ButtonExit { get; private set; }

        public event Action OnEnter
        {
            add { _onEnter += value; }
            remove { _onEnter -= value; }
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            ButtonStart = GameObject.Find(BUTTON_START).GetComponent<Button>();
            ButtonOptions = GameObject.Find(BUTTON_OPTIONS).GetComponent<Button>();
            ButtonExit = GameObject.Find(BUTTON_EXIT).GetComponent<Button>();
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
