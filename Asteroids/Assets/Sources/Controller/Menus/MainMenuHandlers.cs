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
        private ResourceManagerAudioClips _audioClips;
        private SoundSystemPlayController _playAudio;

        #endregion


        #region ClassLifeCycles

        public MainMenuHandlers(
            GameObject mainMenu,
            SoundSystemVolumeController volumeController,
            GraphicsQualityController graphicsQualityController,
            SoundSystemPlayController soundSystemPlayController,
            ResourceManagerAudioClips audioClips,
            SettingsData settingsData)
        {
            _menuElements = mainMenu.GetComponent<MainMenuElements>();
            _playAudio = soundSystemPlayController;
            _audioClips = audioClips;

            _optionsController = new MainMenuHandlersOptions(mainMenu, this, volumeController, graphicsQualityController, soundSystemPlayController, audioClips, settingsData);

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
            _menuElements.ButtonOptions.interactable = visible;
            _menuElements.ButtonExit.interactable = visible;
        }

        private void SubscribeOnEvent()
        {
            _menuElements.ButtonStart.onClick.AddListener(ButtonStartOnClickHandler);
            _menuElements.ButtonOptions.onClick.AddListener(ButtonOptionsOnClickHandler);
            _menuElements.ButtonExit.onClick.AddListener(ButtonExitOnClickHandler);
            _menuElements.OnEnter += ButtonOnPointerEnterHandler;
        }

        private void UnsubscribeOnEvent()
        {
            _menuElements.ButtonStart.onClick.RemoveListener(ButtonStartOnClickHandler);
            _menuElements.ButtonOptions.onClick.RemoveListener(ButtonOptionsOnClickHandler);
            _menuElements.ButtonExit.onClick.RemoveListener(ButtonExitOnClickHandler);
            _menuElements.OnEnter -= ButtonOnPointerEnterHandler;
        }

        private void ButtonStartOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.ButtonClick);
            SceneManager.LoadScene(Scenes.FIRST_LEVEL);
        }

        private void ButtonOptionsOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.ButtonClick);
            SetMenuButtonsVisible(false);
            _optionsController.SetMenuOptionsVisible(true);
        }

        private void ButtonExitOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.ButtonClick);

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void ButtonOnPointerEnterHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.ButtonEnter);
        }

        #endregion

    }
}
