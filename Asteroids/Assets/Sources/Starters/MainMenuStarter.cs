using UnityEngine;


namespace Asteroids
{
    public sealed class MainMenuStarter : MonoBehaviour
    {

        #region Fields

        private GraphicsQualityController _graphicsQualityController;
        private ResourceManager _resources;
        private ResourceManagerAudioClips _resourcesAudioClips;
        private SettingsData _settingsData;
        private SoundSystemPlayController _soundSystemPlayController;
        private SoundSystemVolumeController _volumeController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _resources = new ResourceManager();
            _resourcesAudioClips = new ResourceManagerAudioClips();
            _soundSystemPlayController = new SoundSystemPlayController();
            _settingsData = DataSaveLoadRepo.LoadSettings();
            _volumeController = new SoundSystemVolumeController(_settingsData);
            _graphicsQualityController = new GraphicsQualityController(_settingsData);

            new MainMenuHandlers(
                Instantiate(_resources.MainMenu),
                _volumeController,
                _graphicsQualityController,
                _soundSystemPlayController,
                _resourcesAudioClips,
                _settingsData);

            _soundSystemPlayController.PlaybackMusic(_resourcesAudioClips.AudioClipMenu);
        }

        private void Start()
        {
            _volumeController.ApplySettings();
        }

        #endregion

    }
}
