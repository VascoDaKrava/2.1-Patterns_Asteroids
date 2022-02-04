using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


namespace Asteroids
{
    public sealed class PauseMenuHandlers : UpdatableObject
    {

        #region Fields

        private PauseMenuElements _pauseMenuElements;
        private ResourceManagerAudioClips _audioClips;
        private SoundSystemPlayController _playAudio;

        #endregion


        #region Properties

        #endregion


        #region ClassLifeCycles

        public PauseMenuHandlers(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            GameObject pauseMenu,
            AudioMixer audioMixer) : base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _pauseMenuElements = pauseMenu.GetComponent<PauseMenuElements>();

            SubscribeOnEvent();
        }

        ~PauseMenuHandlers()
        {
            UnsubscribeOnEvent();
        }

        #endregion


        #region Methods

        private void SubscribeOnEvent()
        {
            _pauseMenuElements.ButtonBackToMenu.onClick.AddListener(ButtonBackToMenuOnClickHandler);
            _pauseMenuElements.ButtonResume.onClick.AddListener(ButtonResumeOnClickHandler);
            _pauseMenuElements.OnEnter += ButtonOnPointerEnterHandler;
        }

        private void UnsubscribeOnEvent()
        {
            _pauseMenuElements.ButtonBackToMenu.onClick.RemoveListener(ButtonBackToMenuOnClickHandler);
            _pauseMenuElements.ButtonResume.onClick.RemoveListener(ButtonResumeOnClickHandler);
            _pauseMenuElements.OnEnter -= ButtonOnPointerEnterHandler;
        }

        private void ButtonResumeOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonClick);
        }

        private void ButtonBackToMenuOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonClick);
            SceneManager.LoadScene(Scenes.MAIN_MENU);
        }

        private void ButtonOnPointerEnterHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonEnter);
        }

        private void CheckPause()
        {

        }

        #endregion


        #region UpdatableObject / IUpdatable

        public override void LetUpdate()
        {
            CheckPause();
        }

        #endregion

    }
}
