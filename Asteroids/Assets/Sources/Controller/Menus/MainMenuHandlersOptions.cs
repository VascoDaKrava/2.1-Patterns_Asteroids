using System;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    /// <summary>
    /// MainMenu / Options items handlers
    /// </summary>
    public sealed class MainMenuHandlersOptions
    {

        #region Fields

        private readonly float[] _sliderValueConverter = new float[7] { -80.0f, -30.0f, -20.0f, -15.0f, -10.0f, -5.0f, 0.0f };

        private GraphicsQualityController _graphicsQuality;
        private MainMenuElementsOptions _optionsMenuElements;
        private MainMenuHandlers _menuController;
        private SettingsData _settingsData;
        private SoundSystemVolumeController _volumeController;
        private SoundSystemPlayController _audioPlay;

        #endregion


        #region ClassLifeCycles

        public MainMenuHandlersOptions(
            GameObject mainMenu,
            MainMenuHandlers menuController,
            SoundSystemVolumeController volumeController,
            GraphicsQualityController graphicsQualityController,
            SoundSystemPlayController soundSystemPlayController,
            SettingsData settingsData)
        {
            _graphicsQuality = graphicsQualityController;
            _menuController = menuController;
            _optionsMenuElements = mainMenu.GetComponent<MainMenuElementsOptions>();
            _audioPlay = soundSystemPlayController;
            _settingsData = settingsData;
            _volumeController = volumeController;

            SetInteractableValues();

            SubscribeOnEvent();

            SetMenuOptionsVisible(false);
        }

        ~MainMenuHandlersOptions()
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

            _optionsMenuElements.DropdownGraphicsQuality.onValueChanged.AddListener(DropdownGraphicsQualityOnValueChangesHandler);
        }

        private void UnsubscribeOnEvent()
        {
            _optionsMenuElements.ButtonBack.onClick.RemoveListener(ButtonBackOnClickHandler);
            _optionsMenuElements.SliderVolumeMusic.onValueChanged.RemoveListener(SliderVolumeMusicOnValueChangedHandler);
            _optionsMenuElements.SliderVolumeMenu.onValueChanged.RemoveListener(SliderVolumeMenuOnValueChangedHandler);
            _optionsMenuElements.SliderVolumeSFX.onValueChanged.RemoveListener(SliderVolumeSFXOnValueChangedHandler);

            _optionsMenuElements.DropdownGraphicsQuality.onValueChanged.RemoveListener(DropdownGraphicsQualityOnValueChangesHandler);
        }

        private void SetInteractableValues()
        {
            SetSoundValues();
            SetGraphicsValues();
        }

        private void SetSoundValues()
        {
            _optionsMenuElements.SliderVolumeMenu.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeMenu);
            _optionsMenuElements.SliderVolumeMusic.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeMusic);
            _optionsMenuElements.SliderVolumeSFX.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeSFX);
        }

        private void SetGraphicsValues()
        {
            _optionsMenuElements.DropdownGraphicsQuality.ClearOptions();
            _optionsMenuElements.DropdownGraphicsQuality.AddOptions(new List<string>(QualitySettings.names));
            _optionsMenuElements.DropdownGraphicsQuality.value = _settingsData.GraphicsQuality;
        }

        private void ButtonBackOnClickHandler()
        {
            _audioPlay.PlaybackMenu(_audioPlay.AudioClips.ButtonClick);
            _volumeController.SaveSoundSettings();
            _graphicsQuality.SaveGraphicsSettings();
            DataSaveLoadRepo.SaveSettings(_settingsData);
            _menuController.SetMenuButtonsVisible(true);
            SetMenuOptionsVisible(false);
        }

        private void DropdownGraphicsQualityOnValueChangesHandler(int value)
        {
            _graphicsQuality.GraphicsQualityLevel = value;
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
