using System;
using UnityEngine;


namespace Asteroids
{
    public sealed class MainMenuControllerOptions
    {

        #region Fields

        private readonly float[] _sliderValueConverter = new float[7] { -80.0f,  -30.0f, -20.0f, -15.0f, -10.0f, -5.0f, 0.0f};

        private MainMenuElementsOptions _optionsMenuElements;
        private MainMenuController _menuController;
        private SoundSystemVolumeController _volumeController;
        private SoundSystemPlayController _playAudio;
        private ResourceManagerAudioClips _audioClips;

        #endregion


        #region ClassLifeCycles

        public MainMenuControllerOptions(
            GameObject mainMenu,
            MainMenuController menuController,
            SoundSystemVolumeController volumeController,
            SoundSystemPlayController soundSystemPlayController,
            ResourceManagerAudioClips audioClips)
        {
            _optionsMenuElements = mainMenu.GetComponent<MainMenuElementsOptions>();
            _menuController = menuController;
            _volumeController = volumeController;
            _playAudio = soundSystemPlayController;
            _audioClips = audioClips;

            SetSlidersValue();

            SubscribeOnEvent();

            SetMenuOptionsVisible(false);
        }

        ~MainMenuControllerOptions()
        {
            UnsubscribeOnEvent();
        }

        #endregion


        #region Methods

        public void SetMenuOptionsVisible(bool visible)
        {
            _optionsMenuElements.MenuOptions.gameObject.SetActive(visible);
        }

        private void SubscribeOnEvent()
        {
            _optionsMenuElements.ButtonBack.onClick.AddListener(ButtonBackOnClickHandler);
            _optionsMenuElements.SliderVolumeMusic.onValueChanged.AddListener(SliderVolumeMusicOnValueChangedHandler);
            _optionsMenuElements.SliderVolumeMenu.onValueChanged.AddListener(SliderVolumeMenuOnValueChangedHandler);
            _optionsMenuElements.SliderVolumeSFX.onValueChanged.AddListener(SliderVolumeSFXOnValueChangedHandler);
        }

        private void UnsubscribeOnEvent()
        {
            _optionsMenuElements.ButtonBack.onClick.RemoveListener(ButtonBackOnClickHandler);
            _optionsMenuElements.SliderVolumeMusic.onValueChanged.RemoveListener(SliderVolumeMusicOnValueChangedHandler);
            _optionsMenuElements.SliderVolumeMenu.onValueChanged.RemoveListener(SliderVolumeMenuOnValueChangedHandler);
            _optionsMenuElements.SliderVolumeSFX.onValueChanged.RemoveListener(SliderVolumeSFXOnValueChangedHandler);
        }

        private void SetSlidersValue()
        {
            _optionsMenuElements.SliderVolumeMenu.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeMenu);
            _optionsMenuElements.SliderVolumeMusic.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeMusic);
            _optionsMenuElements.SliderVolumeSFX.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeSFX);
        }

        private void ButtonBackOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonClick);
            _volumeController.SaveSettings();
            _menuController.SetMenuButtonsVisible(true);
            SetMenuOptionsVisible(false);
        }

        private void SliderVolumeMusicOnValueChangedHandler(float value)
        {
            _volumeController.VolumeMusic = _sliderValueConverter[(int)value];
        }

        private void SliderVolumeMenuOnValueChangedHandler(float value)
        {
            _volumeController.VolumeMenu = _sliderValueConverter[(int)value];
        }

        private void SliderVolumeSFXOnValueChangedHandler(float value)
        {
            _volumeController.VolumeSFX = _sliderValueConverter[(int)value];
        }

        #endregion

    }
}
