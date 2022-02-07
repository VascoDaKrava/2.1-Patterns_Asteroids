#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Asteroids
{
    /// <summary>
    /// MainMenu items handlers
    /// </summary>
    public sealed class MainMenuHandlers
    {

        #region Fields

        private MainMenuElements _menuElements;
        private MainMenuHandlersOptions _optionsController;
        private SoundSystemPlayController _audioPlay;

        #endregion


        #region ClassLifeCycles

        public MainMenuHandlers(
            GameObject mainMenu,
            SoundSystemVolumeController volumeController,
            GraphicsQualityController graphicsQualityController,
            SoundSystemPlayController soundSystemPlayController,
            SettingsData settingsData)
        {
            _menuElements = mainMenu.GetComponent<MainMenuElements>();
            _audioPlay = soundSystemPlayController;

            _optionsController = new MainMenuHandlersOptions(mainMenu, this, volumeController, graphicsQualityController, soundSystemPlayController, settingsData);

            SubscribeOnEvent();
        }

        ~MainMenuHandlers()
        {
            UnsubscribeOnEvent();
        }

        #endregion


        #region Methods

        public void SetMenuButtonsVisible(bool visible)
        {
            _menuElements.ButtonStart.interactable = visible;
            _menuElements.ButtonStartMulti.interactable = visible;
            _menuElements.ButtonOptions.interactable = visible;
            _menuElements.ButtonExit.interactable = visible;
        }

        private void SubscribeOnEvent()
        {
            _menuElements.ButtonStart.onClick.AddListener(ButtonStartOnClickHandler);
            _menuElements.ButtonStartMulti.onClick.AddListener(ButtonStartMultiOnClickHandler);
            _menuElements.ButtonOptions.onClick.AddListener(ButtonOptionsOnClickHandler);
            _menuElements.ButtonExit.onClick.AddListener(ButtonExitOnClickHandler);
            _menuElements.OnEnter += ButtonOnPointerEnterHandler;
        }

        private void UnsubscribeOnEvent()
        {
            _menuElements.ButtonStart.onClick.RemoveListener(ButtonStartOnClickHandler);
            _menuElements.ButtonStartMulti.onClick.RemoveListener(ButtonStartMultiOnClickHandler);
            _menuElements.ButtonOptions.onClick.RemoveListener(ButtonOptionsOnClickHandler);
            _menuElements.ButtonExit.onClick.RemoveListener(ButtonExitOnClickHandler);
            _menuElements.OnEnter -= ButtonOnPointerEnterHandler;
        }

        private void ButtonStartOnClickHandler()
        {
            _audioPlay.PlaybackMenu(_audioPlay.AudioClips.ButtonClick);
            SceneManager.LoadScene(Scenes.FIRST_LEVEL);
        }

        private void ButtonStartMultiOnClickHandler()
        {
            _audioPlay.PlaybackMenu(_audioPlay.AudioClips.ButtonClick);
            _menuElements.TMProMessage.alpha = 1.0f;
        }

        private void ButtonOptionsOnClickHandler()
        {
            _audioPlay.PlaybackMenu(_audioPlay.AudioClips.ButtonClick);
            SetMenuButtonsVisible(false);
            _optionsController.SetMenuOptionsVisible(true);
        }

        private void ButtonExitOnClickHandler()
        {
            _audioPlay.PlaybackMenu(_audioPlay.AudioClips.ButtonClick);

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void ButtonOnPointerEnterHandler()
        {
            _audioPlay.PlaybackMenu(_audioPlay.AudioClips.ButtonEnter);
        }

        #endregion

    }
}
