using System;


namespace Asteroids
{
    public sealed class MainMenuOptionsController
    {

        #region Fields

        private readonly float[] _sliderValueConverter = new float[7] { -80.0f,  -30.0f, -20.0f, -15.0f, -10.0f, -5.0f, 0.0f};

        private MainMenuElements _menuElements;
        private MainMenuController _menuController;
        private SoundSystemVolumeController _volumeController;
        private SoundSystemPlayController _playAudio;
        private ResourceManagerAudioClips _audioClips;

        #endregion


        #region ClassLifeCycles

        public MainMenuOptionsController(
            MainMenuElements menuElements,
            MainMenuController menuController,
            SoundSystemVolumeController volumeController,
            SoundSystemPlayController soundSystemPlayController,
            ResourceManagerAudioClips audioClips)
        {
            _menuElements = menuElements;
            _menuController = menuController;
            _volumeController = volumeController;
            _playAudio = soundSystemPlayController;
            _audioClips = audioClips;

            SetMenuOptionsVisible(false);

            volumeController.LoadSettings();
            SetSlidersValue();

            SubscribeOnEvent();
        }

        ~MainMenuOptionsController()
        {
            UnsubscribeOnEvent();
        }

        #endregion


        #region Methods

        public void SetMenuOptionsVisible(bool visible)
        {
            _menuElements.MenuOptions.gameObject.SetActive(visible);
        }

        private void SubscribeOnEvent()
        {
            _menuElements.ButtonBack.onClick.AddListener(ButtonBackOnClickHandler);
            _menuElements.SliderVolumeMusic.onValueChanged.AddListener(SliderVolumeMusicOnValueChangedHandler);
            _menuElements.SliderVolumeMenu.onValueChanged.AddListener(SliderVolumeMenuOnValueChangedHandler);
            _menuElements.SliderVolumeSFX.onValueChanged.AddListener(SliderVolumeSFXOnValueChangedHandler);
        }

        private void UnsubscribeOnEvent()
        {
            _menuElements.ButtonBack.onClick.RemoveListener(ButtonBackOnClickHandler);
            _menuElements.SliderVolumeMusic.onValueChanged.RemoveListener(SliderVolumeMusicOnValueChangedHandler);
            _menuElements.SliderVolumeMenu.onValueChanged.RemoveListener(SliderVolumeMenuOnValueChangedHandler);
            _menuElements.SliderVolumeSFX.onValueChanged.RemoveListener(SliderVolumeSFXOnValueChangedHandler);
        }

        private void SetSlidersValue()
        {
            _menuElements.SliderVolumeMenu.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeMenu);
            _menuElements.SliderVolumeMusic.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeMenu);
            _menuElements.SliderVolumeSFX.value = Array.IndexOf(_sliderValueConverter, _volumeController.VolumeMenu);
        }

        private void ButtonBackOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonClick);
            SetMenuOptionsVisible(false);
            _menuController.SetMenuButtonsVisible(true);
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
