using UnityEngine.Audio;


namespace Asteroids
{
    public sealed class SoundSystemVolumeController
    {

        #region Fields

        private AudioMixer _audioMixer;
        private ResourceManagerSettings _settings;

        #endregion


        #region Properties

        private float VolumeMaster
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerGroups.MASTER, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerGroups.MASTER, value);
            }
        }

        private float VolumeMenu
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerGroups.MENU, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerGroups.MENU, value);
            }
        }

        private float VolumeMusic
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerGroups.MUSIC, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerGroups.MUSIC, value);
            }
        }

        private float VolumeSFX
        {
            get
            {
                _audioMixer.GetFloat(AudioMixerGroups.SFX, out float value);
                return value;
            }
            set
            {
                _audioMixer.SetFloat(AudioMixerGroups.SFX, value);
            }
        }

        #endregion


        #region ClassLifeCycles

        public SoundSystemVolumeController(ResourceManagerAudioClips resourceManagerAudioClips, ResourceManagerSettings resourceManagerSettings)
        {
            _audioMixer = resourceManagerAudioClips.AudioMixerResource;
            _settings = resourceManagerSettings;
        }

        #endregion


        #region Methods

        public void LoadSettings()
        {
            VolumeMaster = _settings.SoundSettings.VolumeMaster;
            VolumeMenu = _settings.SoundSettings.VolumeMenu;
            VolumeMusic = _settings.SoundSettings.VolumeMusic;
            VolumeSFX = _settings.SoundSettings.VolumeSFX;
        }

        #endregion

    }
}
