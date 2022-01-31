using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Asteroids
{
    public sealed class MainMenuElements : MonoBehaviour, IPointerEnterHandler
    {

        #region Fields

        #region MainButtons

        private const string BUTTON_START = "ButtonStart";
        private const string BUTTON_OPTIONS = "ButtonOptions";
        private const string BUTTON_EXIT = "ButtonExit";

        #endregion


        #region MenuOptions

        private const string PANEL_MENU_OPTIONS = "MenuOptions";

        private const string SLIDER_VOLUME_MUSIC = "SliderVolumeMusic";
        private const string SLIDER_VOLUME_EFFECTS = "SliderVolumeEffects";
        private const string SLIDER_VOLUME_MENU = "SliderVolumeMenu";

        private const string DROPDOWN_GRAPHICS_QUALITY = "DropdownGraphicsQuality";

        private const string BUTTON_BACK = "ButtonBack";

        #endregion

        private event Action _onEnter;

        #endregion


        #region Properties

        public Button ButtonStart { get; private set; }

        public Button ButtonOptions { get; private set; }

        public Button ButtonExit { get; private set; }

        public Button ButtonBack { get; private set; }

        public Transform MenuOptions { get; private set; }

        public Slider SliderVolumeMusic { get; private set; }

        public Slider SliderVolumeSFX { get; private set; }

        public Slider SliderVolumeMenu { get; private set; }

        public Dropdown DropdownGraphicsQuality { get; private set; }

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
            ButtonBack = GameObject.Find(BUTTON_BACK).GetComponent<Button>();

            MenuOptions = GameObject.Find(PANEL_MENU_OPTIONS).GetComponent<Transform>();

            SliderVolumeMusic = GameObject.Find(SLIDER_VOLUME_MUSIC).GetComponent<Slider>();
            SliderVolumeSFX = GameObject.Find(SLIDER_VOLUME_EFFECTS).GetComponent<Slider>();
            SliderVolumeMenu = GameObject.Find(SLIDER_VOLUME_MENU).GetComponent<Slider>();

            DropdownGraphicsQuality = GameObject.Find(DROPDOWN_GRAPHICS_QUALITY).GetComponent<Dropdown>();
        }

        #endregion


        #region IPointerEnterHandler

        public void OnPointerEnter(PointerEventData eventData)
        {
            _onEnter.Invoke();
        }

        #endregion

    }
}