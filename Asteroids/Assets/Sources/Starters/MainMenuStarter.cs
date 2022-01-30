using UnityEngine;


namespace Asteroids
{
    public sealed class MainMenuStarter : MonoBehaviour
    {

        #region Fields

        private ResourceManager _resources;
        private ResourceManagerAudioClips _resourcesAudioClips;
        private ResourceManagerSettings _resourcesSettings;
        private SoundSystemPlayController _soundSystemPlayController;
        private SoundSystemVolumeController _volumeController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _resources = new ResourceManager();
            _resourcesAudioClips = new ResourceManagerAudioClips();
            _soundSystemPlayController = new SoundSystemPlayController();
            _resourcesSettings = new ResourceManagerSettings();

            _volumeController = new SoundSystemVolumeController(_resourcesAudioClips, _resourcesSettings);

            new MainMenuController(
                Instantiate(_resources.MainMenu).GetComponent<MainMenuElements>(),
                _volumeController,
                _soundSystemPlayController,
                _resourcesAudioClips);

            _soundSystemPlayController.PlaybackMusic(_resourcesAudioClips.AudioClipMenu);
        }

        private void Start()
        {
            _volumeController.LoadSettings();
        }

        #endregion
    }
}
