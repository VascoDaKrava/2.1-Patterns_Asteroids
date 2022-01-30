#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public sealed class MainMenuController
    {

        #region Fields

        private MainMenuElements _menuElements;
        private MainMenuOptionsController _optionsController;
        private ResourceManagerAudioClips _audioClips;
        private SoundSystemPlayController _playAudio;

        #endregion


        #region ClassLifeCycles

        public MainMenuController(
            MainMenuElements menuElements,
            SoundSystemVolumeController volumeController,
            SoundSystemPlayController soundSystemPlayController,
            ResourceManagerAudioClips audioClips)
        {
            _menuElements = menuElements;
            _playAudio = soundSystemPlayController;
            _audioClips = audioClips;

            _optionsController = new MainMenuOptionsController(menuElements, this, volumeController, soundSystemPlayController, audioClips);

            _optionsController.SetMenuOptionsVisible(false);

            SubscribeOnEvent();
        }

        ~MainMenuController()
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
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonClick);
            SceneManager.LoadScene(Scenes.FIRST_LEVEL);
        }

        private void ButtonOptionsOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonClick);
            SetMenuButtonsVisible(false);
            _optionsController.SetMenuOptionsVisible(true);
        }

        private void ButtonExitOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonClick);

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void ButtonOnPointerEnterHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonEnter);
        }

        #endregion

    }
}
