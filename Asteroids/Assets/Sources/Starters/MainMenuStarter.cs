using UnityEngine;


namespace Asteroids
{
    public sealed class MainMenuStarter : MonoBehaviour
    {

        #region Fields

        private ResourceManager _resources;
        private ResourceManagerAudioClips _resourcesAudioClips;
        private SoundSystemPlayController _soundSystemPlayController;
        private SoundSystemVolumeController _volumeController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _resources = new ResourceManager();
            _resourcesAudioClips = new ResourceManagerAudioClips();
            _soundSystemPlayController = new SoundSystemPlayController();

            _volumeController = new SoundSystemVolumeController();

            new MainMenuController(
                Instantiate(_resources.MainMenu).GetComponent<MainMenuElements>(),
                _volumeController,
                _soundSystemPlayController,
                _resourcesAudioClips);

            _soundSystemPlayController.PlaybackMusic(_resourcesAudioClips.AudioClipMenu);
        }

        private void Start()
        {
            _volumeController.ApplySettings();
        }

        #endregion

    }
}
