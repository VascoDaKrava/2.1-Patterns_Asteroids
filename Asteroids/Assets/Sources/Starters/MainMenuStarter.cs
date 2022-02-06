using UnityEngine;


namespace Asteroids
{
    public sealed class MainMenuStarter : MonoBehaviour
    {

        #region Fields

        private GraphicsQualityController _graphicsQualityController;
        private ResourceManager _resources;
        private SettingsData _settingsData;
        private SoundSystemPlayController _soundSystemPlayController;
        private SoundSystemVolumeController _volumeController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _resources = new ResourceManager();
            _soundSystemPlayController = new SoundSystemPlayController();
            _settingsData = DataSaveLoadRepo.LoadSettings();
            _volumeController = new SoundSystemVolumeController(_settingsData, _resources.AudioMixer);
            _graphicsQualityController = new GraphicsQualityController(_settingsData);

            new MainMenuHandlers(
                Instantiate(_resources.MainMenu),
                _volumeController,
                _graphicsQualityController,
                _soundSystemPlayController,
                _settingsData);

            _soundSystemPlayController.PlaybackMusic(_soundSystemPlayController.AudioClips.Menu);
        }

        private void Start()
        {
            _volumeController.ApplySettings();
            _resources.AudioMixer.SetFloat(AudioMixerParams.LOWPASS, AudioMixerParams.LOWPASS_HIGH);
        }

        #endregion

    }
}
