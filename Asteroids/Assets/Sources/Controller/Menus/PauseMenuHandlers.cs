using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


namespace Asteroids
{
    /// <summary>
    /// PauseMenu items handlers
    /// </summary>
    public sealed class PauseMenuHandlers : UpdatableObject
    {

        #region Fields

        private AudioMixer _audioMixer;
        private GameObject _pauseMenuGameObject;
        private PauseMenuElements _pauseMenuElements;
        private ResourceManagerAudioClips _audioClips;
        private SoundSystemPlayController _playAudio;

        private bool _isMenuHide;

        #endregion


        #region ClassLifeCycles

        public PauseMenuHandlers(
            CreateUpdatableObjectEvent createUpdatableObjectEvent,
            DestroyUpdatableObjectEvent destroyUpdatableObjectEvent,
            GameObject pauseMenu,
            AudioMixer audioMixer,
            SoundSystemPlayController playAudio,
            ResourceManagerAudioClips audioClips) : base(createUpdatableObjectEvent, destroyUpdatableObjectEvent)
        {
            _audioClips = audioClips;
            _audioMixer = audioMixer;
            _pauseMenuGameObject = pauseMenu;
            _playAudio = playAudio;
            _pauseMenuElements = pauseMenu.GetComponent<PauseMenuElements>();

            _isMenuHide = false;

            SubscribeOnEvent();

            ChangeMenuState();
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
            ChangeMenuState();
        }

        private void ButtonBackToMenuOnClickHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonClick);
            ChangeMenuState();
            SceneManager.LoadScene(Scenes.MAIN_MENU);
        }

        private void ButtonOnPointerEnterHandler()
        {
            _playAudio.PlaybackMenu(_audioClips.AudioClipButtonEnter);
        }

        private void CheckPause()
        {
            if (InputManager.isPause)
            {
                ChangeMenuState();
            }
        }

        public void ChangeMenuState()
        {
            _isMenuHide = !_isMenuHide;

            _pauseMenuGameObject.SetActive(!_isMenuHide);

            if (_isMenuHide)
            {
                Time.timeScale = 1;
                _audioMixer.SetFloat(AudioMixerParams.LOWPASS, AudioMixerParams.LOWPASS_HIGH);
            }
            else
            {
                Time.timeScale = 0;
                _audioMixer.SetFloat(AudioMixerParams.LOWPASS, AudioMixerParams.LOWPASS_LOW);
            }
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
