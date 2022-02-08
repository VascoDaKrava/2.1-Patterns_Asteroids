using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Asteroids
{
    public sealed class MainMenuElementsOptions : MonoBehaviour
    {

        #region Fields

        private const string PANEL_MENU_OPTIONS = "MenuOptions";

        private const string SLIDER_VOLUME_MUSIC = "SliderVolumeMusic";
        private const string SLIDER_VOLUME_EFFECTS = "SliderVolumeEffects";
        private const string SLIDER_VOLUME_MENU = "SliderVolumeMenu";

        private const string DROPDOWN_GRAPHICS_QUALITY = "DropdownGraphicsQuality";

        private const string BUTTON_BACK = "ButtonBack";

        #endregion


        #region Properties

        public Button ButtonBack { get; private set; }
        public Transform MenuOptions { get; private set; }
        public Slider SliderVolumeMusic { get; private set; }
        public Slider SliderVolumeSFX { get; private set; }
        public Slider SliderVolumeMenu { get; private set; }
        public TMP_Dropdown DropdownGraphicsQuality { get; private set; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            ButtonBack = GameObject.Find(BUTTON_BACK).GetComponent<Button>();

            MenuOptions = GameObject.Find(PANEL_MENU_OPTIONS).GetComponent<Transform>();

            SliderVolumeMusic = GameObject.Find(SLIDER_VOLUME_MUSIC).GetComponent<Slider>();
            SliderVolumeSFX = GameObject.Find(SLIDER_VOLUME_EFFECTS).GetComponent<Slider>();
            SliderVolumeMenu = GameObject.Find(SLIDER_VOLUME_MENU).GetComponent<Slider>();

            DropdownGraphicsQuality = GameObject.Find(DROPDOWN_GRAPHICS_QUALITY).GetComponent<TMP_Dropdown>();
        }

        #endregion

    }
}
